using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Diagnostics;
using UxGame_Testing_Utility.Entities;

namespace UxGame_Testing_Utility.Services
{
    internal sealed class ExcelService
    {
        private readonly string? _filePath;
        private readonly IWorkbook? _workbook;     

        private readonly int _skillIdColumnIndex;
        private readonly int _buletIdColumnIndex;
        private readonly int _shotrIdColumnIndex;

        private const string DATA_SHEET_NAME = "Data";
        private const string SKILLID_COLNAME = "Id";
        private const string BULETID_COLNAME = "BulletId";
        private const string SHOTRID_COLNAME = "ShooterId";

        private ISheet DataSheet => 
            _workbook!.GetSheet(DATA_SHEET_NAME);

        internal ExcelService(string excelFilePath, out string? errmsg)
        {
            errmsg = default;

            #region Init Excel File

            _filePath = excelFilePath ?? throw new ArgumentNullException(nameof(excelFilePath));

            try
            {
                using FileStream file = new(_filePath, FileMode.Open, FileAccess.ReadWrite);          
                _workbook = new XSSFWorkbook(file);
            }
            catch (IOException)
            {
                errmsg = "file is in occupying, please close and retry.";
                return;
            }
            #endregion

            #region Init Basic Properties
            try
            {
                _skillIdColumnIndex = TryGetColumnIndex(SKILLID_COLNAME);
                _buletIdColumnIndex = TryGetColumnIndex(BULETID_COLNAME);
                _shotrIdColumnIndex = TryGetColumnIndex(SHOTRID_COLNAME);
            }
            catch (NullReferenceException)
            {
                errmsg = "excel sheet is failed to init.";
                return;
            }
            catch (KeyNotFoundException e)
            {
                errmsg = $"name {e.Message} cannot be found in file.";
                return;
            }
            #endregion 
        }
        internal bool GetSkillGroup(string targetId, out SkillGroup group, out string? errmsg)
        {
            List<Skill> skillsInGroup = new();
            for (int i = 1; i <= DataSheet!.LastRowNum; i++)
            {
                IRow row = DataSheet.GetRow(i);
                if (row == null)
                    continue;

                var currentId = row.GetCell(_skillIdColumnIndex)?.ToString();
                if (string.IsNullOrEmpty(currentId))
                    continue;

                if (Skill.IsSame(currentId, targetId))
                {
                    skillsInGroup.Add(new Skill(
                        Id: currentId,
                        BulletId: row.GetCell(_buletIdColumnIndex).ToString()!,
                        ShooterId: row.GetCell(_shotrIdColumnIndex).ToString()!
                        ));
                }
            }

            if (skillsInGroup.Count > 0)
            {
                group = new(skillsInGroup.ToArray());
                errmsg = null;
                return true;
            }
            else
            {
                group = default;
                errmsg = "skill in given id was not found.";
                return false;
            }
        }
        internal bool ApplySkillGroupDataOn(SkillGroup skillGroup, int rowIndex, out string? errmsg)
        {
            var testAreaSkillId = DataSheet!.GetRow(rowIndex).GetCell(_skillIdColumnIndex).ToString();

            foreach (var data in skillGroup.Skills)
            {
                var currentAreaId = DataSheet.GetRow(rowIndex).GetCell(_skillIdColumnIndex).ToString();
                if (!Skill.IsSame(currentAreaId!, testAreaSkillId!))
                {
                    errmsg = 
                        $"test case writing overflow: " +
                        $"test area only in id {testAreaSkillId}, " +
                        $"but now is flushing in {currentAreaId}. " +
                        $"please check the lv count of testskill.";
                    return false;
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
                errmsg = e.Message;
                return false;
            }

            errmsg = default;
            return true;
        }

        private ExcelService() { }
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
