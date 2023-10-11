using NPOI.SS.Formula.PTG;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Diagnostics;
using UxGame_Testing_Utility.Entities;

namespace UxGame_Testing_Utility.Services
{
    internal sealed class ExcelService
    {
        private readonly IWorkbook? _excelFile;

        private const string DATA_SHEET_NAME = "Data";
        private const string SKILLID_COLNAME = "Id";
        private const string BULETID_COLNAME = "BulletId";
        private const string SHOTRID_COLNAME = "ShooterId";

        internal ExcelService(string excelFilePath, out string? errmsg)
        {
            errmsg = default;
            try
            {
                using FileStream file = new(
                excelFilePath ?? throw new ArgumentNullException(nameof(excelFilePath)),
                FileMode.Open,
                FileAccess.ReadWrite
                );
                _excelFile = new XSSFWorkbook(file);
            }
            catch (IOException)
            {
                errmsg = "file is in occupying, please close and retry.";
            }
        }
        internal bool GetSkillGroup(string targetId, out SkillGroup group, out string? errmsg)
        {
            #region Init Table & Properties

            var sheet = _excelFile!.GetSheet(DATA_SHEET_NAME);       
            
            if (!TryGetColumnIndex(SKILLID_COLNAME, sheet, out int skillIdColIndex))
            {
                group = default;
                errmsg = $"column <{SKILLID_COLNAME}> was not found in sheet";
                return false;
            }
            if (!TryGetColumnIndex(BULETID_COLNAME, sheet, out int bulletIdColIndex))
            {
                group = default;
                errmsg = $"column <{BULETID_COLNAME}> was not found in sheet";
                return false;
            }
            if (!TryGetColumnIndex(SHOTRID_COLNAME, sheet, out int shooterIdIndex))
            {
                group = default;
                errmsg = $"column <{SHOTRID_COLNAME}> was not found in sheet";
                return false;
            }

            #endregion

            List<Skill> skillsInGroup = new();
            for (int i = 1; i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                if (row == null)
                    continue;

                var currentId = row.GetCell(skillIdColIndex)?.ToString();
                if (string.IsNullOrEmpty(currentId))
                    continue;

                if (Skill.IsSame(currentId, targetId))
                {
                    skillsInGroup.Add(new Skill(
                        Id:        currentId, 
                        BulletId:  row.GetCell(bulletIdColIndex).ToString()!, 
                        ShooterId: row.GetCell(shooterIdIndex).ToString()!
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
            var sheet = _excelFile!.GetSheet(DATA_SHEET_NAME);

            if (!TryGetColumnIndex(SKILLID_COLNAME, sheet, out int skillIdColIndex))
            {
                errmsg = $"column <{SKILLID_COLNAME}> was not found in sheet";
                return false;
            }
            if (!TryGetColumnIndex(BULETID_COLNAME, sheet, out int bulletIdColIndex))
            {
                errmsg = $"column <{BULETID_COLNAME}> was not found in sheet";
                return false;
            }
            if (!TryGetColumnIndex(SHOTRID_COLNAME, sheet, out int shooterIdColIndex))
            {
                errmsg = $"column <{SHOTRID_COLNAME}> was not found in sheet";
                return false;
            }

            var testAreaSkillId = sheet.GetRow(rowIndex).GetCell(skillIdColIndex).ToString();

            foreach (var data in skillGroup.Skills)
            {
                if (sheet.GetRow(rowIndex).GetCell(skillIdColIndex).ToString() != testAreaSkillId )
                {
                    errmsg = "test case writing overflow, please check the lv count of testskill.";
                    return false;
                }
                sheet.GetRow(rowIndex).CreateCell(bulletIdColIndex).SetCellValue(data.BulletId);
                sheet.GetRow(rowIndex).CreateCell(shooterIdColIndex).SetCellValue(data.ShooterId);
                rowIndex++;
            }

            errmsg = default;
            return true;
        }

        private ExcelService()
        {
            _excelFile = default;
        }
        private static bool TryGetColumnIndex(string columnName, ISheet sheet, out int result)
        {
            var headerRow = sheet.GetRow(0);

            for (int i = 0; i < headerRow.LastCellNum; i++)
            {
                if (headerRow.GetCell(i).ToString() == columnName)
                {
                    result = i;
                    return true;
                }
            }
            result = -1;
            return false;
        }
    }
}
