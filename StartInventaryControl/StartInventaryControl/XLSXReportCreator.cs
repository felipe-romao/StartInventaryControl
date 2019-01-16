using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartInventaryControl.Data;
using OfficeOpenXml;
using System.IO;

namespace StartInventaryControl
{
    public class XLSXReportCreator : IReportCreator
    {
        public void Create(string filePath, IList<Variation> variations)
        {
            using (var xlsxFile = new ExcelPackage())
            {
                xlsxFile.Workbook.Worksheets.Add("Lista de produtos");
                var excelWorksheet = xlsxFile.Workbook.Worksheets["Lista de produtos"];
                var cellData = new List<object[]>()
                {
                  new object[] { "NOME", "GENERO", "COR", "TAMANHO", "QUANTIDADE" }
                };
                
                foreach (var variation in variations)
                {
                    cellData.Add(new object[]
                    {
                        variation.Product.Description,
                        variation.Gender,
                        variation.Color,
                        variation.Size,
                        variation.Quantity
                    });
                };

                excelWorksheet.Cells[1, 1].LoadFromArrays(cellData);
                var excelFile = new FileInfo(filePath);
                xlsxFile.SaveAs(excelFile);
            }
        }
    }
}
