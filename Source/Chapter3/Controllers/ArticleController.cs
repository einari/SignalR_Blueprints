using System.Web.Mvc;
using Chapter3.DAL;

namespace Chapter3.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Full(int id)
        {
            var articleContext = new ArticleContext();
            var article = articleContext.GetByID(id);
            return View(article);
        }
    }
}