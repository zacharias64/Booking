using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Web.SessionState;
namespace Book.Controllers
{
    
    
   
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.place = "下列書籍";
            return View();
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