using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Http.Results;
using TerriDataServices.Controllers;
using TerriDataServices.Models.Dto;

namespace TerriDataServices.Tests
{
    [TestClass]
    public class Upratest
    {
        [TestMethod]
        public void TestFronteraAgricola()
        {
            var controller = new ServicesController();
            var result = controller.GetFronteraAgricola() as OkNegotiatedContentResult<IList<FronteraAgricolaDto>>;
            //var result =  as IList<FronteraAgricolaDto>;
            Assert.IsNotNull(result.Content.Count);
        }

        [TestMethod]
        public void TestHectareasAdecuadasIrrigacion()
        {
            var controller = new ServicesController();
            var result = controller.GetHectareasAdecuadasIrrigacion() as OkNegotiatedContentResult<IList<APADTDto>>;
            Assert.IsNotNull(result.Content.Count);
        }
    }
}
