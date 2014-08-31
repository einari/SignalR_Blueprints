using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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