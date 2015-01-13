using System.Web.Mvc;
using Chapter3.DAL;

namespace Chapter3.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Full(int id)
        {
            using (var articleContext = new ArticleContext())
            {
                var article = articleContext.GetArticle(id);
                return View(article);
            }
        }
    }
}