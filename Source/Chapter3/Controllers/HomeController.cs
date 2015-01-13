using System.Web.Mvc;
using Chapter3.DAL;
using Chapter3.Models.News;

namespace Chapter3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var articleContext = new ArticleContext())
            {
                var viewModel = new LandingPageViewModel
                {
                    TopArticles = articleContext.GetTopArticles(),
                    OtherArticles = articleContext.GetOtherArticles()
                };
                return View(viewModel);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}