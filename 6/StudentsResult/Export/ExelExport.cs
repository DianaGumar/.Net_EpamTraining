using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OfficeOpenXml;

namespace Export
{
    public class ExcelExport
    {
        public static string ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        public static string FileDownloadName = $"{DateTime.Now.ToString("yyyy.MM.dd")}.xlsx";

        /// <summary>
        /// Export to excel
        /// </summary>
        /// <param name="col">count colums</param>
        /// <param name=""></param>
        public static byte[] Export<T>(List<T[]> data)
        {
            if (data == null || data.Count == 0) { return null; }

            byte[] fileContents;

            using (var package = new ExcelPackage())
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");

                int j = 0;

                //for columns name's 
                #region
                for (j = 0; j < data.ElementAt(0).Length; j++)
                {
                    workSheet.Cells[1, j + 1].Value = data[0][j];
                    workSheet.Cells[1, j + 1].Style.Font.Bold = true;
                }
                #endregion

                int i;
                for (i = 1; i < data.Count; i++)
                {
                    #region  Header Row
                    for (j = 0; j < data.ElementAt(0).Length; j++)
                    {
                        workSheet.Cells[i + 1, j + 1].Value = data[i][j];
                    }
                    #endregion
                    j = 0;
                }

                fileContents = package.GetAsByteArray();

            }

            return fileContents;
        }

        public static bool Export<T>(List<T[]> data, string Path, string FileName)
        {
            byte[] Buffer = Export(data);
            ExcelPackage package;

            bool Exported = false;
            using (MemoryStream memStream = new MemoryStream(Buffer))
            {
                package = new ExcelPackage(memStream);

                FileInfo fi = new FileInfo(Path + @"\" + FileName + $"_{DateTime.Now.ToString("yyyy.MM.dd")}.xlsx");
                //@"E:\Epam\.Net_EpamTraining\6\1.xlsx"
                package.SaveAs(fi);

                Exported = true;
            }
            
            return Exported;
        }

    }
}
