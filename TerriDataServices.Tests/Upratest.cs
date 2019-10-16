using GemBox.Spreadsheet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Web.Http.Results;
using TerriDataServices.Controllers;
using TerriDataServices.Models.Dto;

namespace TerriDataServices.Tests
{
    [TestClass]
    public class Upratest
    {
        ExcelUtlity eutility;
        [TestInitialize]
        public void TestInitialize()
        {
            eutility = new ExcelUtlity();
        }

        [TestMethod]
        public void TestFronteraAgricola()
        {
            var controller = new ServicesController();
            var result = controller.GetFronteraAgricola() as OkNegotiatedContentResult<IList<FronteraAgricolaDto>>;
            IList<FronteraAgricolaDto> lista = result.Content;

            eutility.convertirAexcel(lista, "FronteraAgricola", "c:\\FronteraAgricola.xlsx");
            Assert.IsNotNull(result.Content.Count);
        }

        [TestMethod]
        public void TestHectareasAdecuadasIrrigacion()
        {
            var controller = new ServicesController();
            var result = controller.GetHectareasAdecuadasIrrigacion() as OkNegotiatedContentResult<IList<APADTDto>>;
            IList<APADTDto> lista = result.Content;
            eutility.convertirAexcel(lista, "HecaterasAdecuadas", "c:\\HectareasAdecuadas.xlsx");
            Assert.IsNotNull(result.Content.Count);
        }





        public static void ExportGenericListToExcel<T>(IList<T> list, string excelFilePath)
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            ExcelFile file = new ExcelFile();
            ExcelWorksheet sheet = file.Worksheets.Add("Exported List");

            for (int i = 0; i < properties.Count; i++)
                sheet.Cells[0, i].Value = properties[i].Name;

            for (int i = 0; i < list.Count; i++)
                for (int j = 0; j < properties.Count; j++)
                    sheet.Cells[i + 1, j].Value = properties[j].GetValue(list[i]);

            file.Save(excelFilePath);
        }
    }
}
