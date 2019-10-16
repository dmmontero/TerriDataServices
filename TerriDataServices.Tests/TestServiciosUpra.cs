using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Http.Results;
using TerriDataServices.Controllers;
using TerriDataServices.Models.Dto;

namespace TerriDataServices.Tests
{
    [TestClass]
    public class TestServiciosUpra
    {
        [TestMethod]
        public void TestFronteraAgricola()
        {
            var controller = new ServicesController();
            var result = controller.GetFronteraAgricola() as OkNegotiatedContentResult<List<FronteraAgricolaDto>>;
            ////var actionResult = controller.GetFronteraAgricola();
            //var result =  as IList<FronteraAgricolaDto>;
            Assert.IsNotNull(result.Content.Count);
        }
    }
}
