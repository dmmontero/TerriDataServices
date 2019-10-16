using System.Collections.Generic;
using TerriDataServices.Controllers;
using TerriDataServices.Models.Dto;
using Xunit;

namespace TerridataXTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestMethod1()
        {
            var controller = new ServicesController();
            var result = controller.GetFronteraAgricola();//as OkNegotiatedContentResult<List<FronteraAgricolaDto>>;
            //var actionResult = controller.GetFronteraAgricola();
            //var result =  as IList<FronteraAgricolaDto>;
            //Assert.IsNotNull result.Count);
        }
    }
}
