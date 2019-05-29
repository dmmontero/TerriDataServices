using System.Web.Http;
using System.Web.Http.Results;

namespace TerriDataServices.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        [ActionName("Index")]
        public IHttpActionResult Index()
        {
            return Redirect("~/swagger");
        }
    }
}
