using System.Web.Mvc;

namespace Chapter3.Controllers
{
    [Authorize]
    public class NewsroomController : Controller
    {
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }
    }
}