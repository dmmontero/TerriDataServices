using System.Web.Http;
using System.Web.Http.Description;

namespace TerriDataServices.Controllers
{

    [ApiExplorerSettings(IgnoreApi = true)]
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
