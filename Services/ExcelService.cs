using NPOI.SS.Formula.Functions;
using NPOI.SS.Formula.PTG;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using UxGame_Testing_Utility.Entities;

namespace UxGame_Testing_Utility.Services
{
    internal sealed class ExcelService
    {
        private readonly string _filePath;

        private IWorkbook? _workbook;     
        private int _skillIdColumnIndex;
        private int _skillNmColumnIndex;
        private int _buletIdColumnIndex;
        private int _shotrIdColumnIndex;

        private const int    IO_TRY_SPACE_MS = 50;
        private const int    MAX_IO_TRYTIMES = 10;     
        private const string DATA_SHEET_NAME = "Data";
        private const string SKILLID_COLNAME = "Id";
        private const string SKILLNM_COLNAME = "Note";
        private const string BULETID_COLNAME = "BulletId";
        private const string SHOTRID_COLNAME = "ShooterId";

        private ISheet DataSheet => 
            _workbook!.GetSheet(DATA_SHEET_NAME);

        internal ExcelService(string excelFilePath)
        {
            _filePath = excelFilePath ?? throw new ArgumentNullException(nameof(excelFilePath));           
        }
        internal async Task<(bool suc, string msg)> InitExcelFile()
        {
            return await Task.Run(() =>
            {
                #region Init Excel File

                for (int times = 0; _workbook == null && times < MAX_IO_TRYTIMES; times++)
                {
                    try
                    {
                        using FileStream file = new(_filePath, FileMode.Open, FileAccess.ReadWrite);
                        _workbook = new XSSFWorkbook(file);
                    }
                    catch (IOException)
                    {
                        Thread.Sleep(IO_TRY_SPACE_MS);
                    }
                }
                if (_workbook == null)
                    return (false, "file is in occupying, please close and retry.");

                #endregion

                #region Init Basic Properties
                try
                {
                    _skillIdColumnIndex = TryGetColumnIndex(SKILLID_COLNAME);
                    _skillNmColumnIndex = TryGetColumnIndex(SKILLNM_COLNAME);
                    _buletIdColumnIndex = TryGetColumnIndex(BULETID_COLNAME);
                    _shotrIdColumnIndex = TryGetColumnIndex(SHOTRID_COLNAME);
                }
                catch (NullReferenceException)
                {
                    return (false, "excel sheet is failed to init.");
                }
                catch (KeyNotFoundException e)
                {
                    return (false, $"name {e.Message} cannot be found in file.");
                }
                #endregion

                return (true, string.Empty);
            });        
        }
        internal async Task<(bool suc, SkillGroup rst, string msg)> GetSkillGroup(string idOrName)
        {
            return await Task.Run(() =>
            {
                List<Skill> skillsInGroup = new();
                string currentName = string.Empty;

                for (int i = 1; i <= DataSheet!.LastRowNum; i++)
                {
                    IRow row = DataSheet.GetRow(i);

                    // get id in current row
                    var currentId = row.GetCell(_skillIdColumnIndex)?.ToString();
                    if (string.IsNullOrEmpty(currentId))
                        continue;

                    // get name in current row
                    var nameInRow = row.GetCell(_skillNmColumnIndex)?.ToString();
                    if (!string.IsNullOrEmpty(nameInRow))
                        currentName = nameInRow;

                    if (Skill.IsSameGroup(currentId, idOrName) || currentName == idOrName)
                    {
                        skillsInGroup.Add(new Skill(
                            Id: currentId,
                            BulletId: row.GetCell(_buletIdColumnIndex).ToString()!,
                            ShooterId: row.GetCell(_shotrIdColumnIndex).ToString()!
                            ));
                    }
                }

                if (skillsInGroup.Count > 0)
                    return (true, new(skillsInGroup.ToArray()), null!);
                else
                    return (false, default(SkillGroup), $"skill [{idOrName}] was not found.");
            });        
        }
        internal async Task<(bool suc, string msg)> ApplySkillGroupDataOn(SkillGroup skillGroup, int rowIndex)
        {
            return await Task.Run(() => 
            {
                var testAreaSkillId = DataSheet!.GetRow(rowIndex).GetCell(_skillIdColumnIndex).ToString();

                foreach (var data in skillGroup.Skills)
                {
                    var currentAreaId = DataSheet.GetRow(rowIndex).GetCell(_skillIdColumnIndex).ToString();
                    if (!Skill.IsSameGroup(currentAreaId!, testAreaSkillId!))
                    {
                        var errmsg =
                            $"test case writing overflow: " +
                            $"test area only in id {testAreaSkillId}, " +
                            $"but now is flushing in {currentAreaId}. " +
                            $"please check the lv count of testskill.";
                        return (false, errmsg);
                    }

                    var bulletIdOrigStyle = DataSheet.GetRow(rowIndex).GetCell(_buletIdColumnIndex).CellStyle;
                    var shoterIdOrigStyle = DataSheet.GetRow(rowIndex).GetCell(_shotrIdColumnIndex).CellStyle;

                    var bulletIdCell = DataSheet.GetRow(rowIndex).CreateCell(_buletIdColumnIndex);
                    var shoterIdCell = DataSheet.GetRow(rowIndex).CreateCell(_shotrIdColumnIndex);

                    bulletIdCell.SetCellValue(data.BulletId);
                    shoterIdCell.SetCellValue(data.ShooterId);
                    bulletIdCell.CellStyle = bulletIdOrigStyle;
                    shoterIdCell.CellStyle = shoterIdOrigStyle;

                    rowIndex++;
                }

                try
                {
                    using FileStream file = new(_filePath!, FileMode.Create, FileAccess.Write);
                    _workbook?.Write(file);
                }
                catch (IOException e)
                {
                    return (false, e.Message);
                }

                return (true, string.Empty);
            });
        }

        private ExcelService() 
        {
            _filePath = string.Empty;
        }
        private int TryGetColumnIndex(string columnName)
        {
            if (DataSheet == null)
                throw new NullReferenceException();

            var headerRow = DataSheet.GetRow(0);
            for (int i = 0; i < headerRow.LastCellNum; i++)
                if (headerRow.GetCell(i).ToString() == columnName)
                    return i;
            
            throw new KeyNotFoundException(columnName);
        }
    }
}
