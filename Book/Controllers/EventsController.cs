using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
namespace Book.Controllers
{
    public class EventsController : Controller
    {
        // GET: Events
        public ActionResult GoHome()
        {
            return View("~/Views/Home/Index.cshtml");
        }
        public ActionResult Shoppingcar()
        {

            return View();
        }
        public ActionResult Bookintro1()
        {

            return View();
        }

        public ActionResult Bookintro2()
        {

            return View();
        }
        public ActionResult Comment()
        {
            return View();
        }
        public ActionResult Order()
        {
            string  Book1OrderNumber= Request["Many1"].ToString();
            Session["Book1Number"] = Book1OrderNumber;
            return RedirectToAction("Comment");
        }
        public ActionResult Order1()
        {
            string Book2OrderNumber = Request["Many2"].ToString();
            Session["Book2Number"] = Book2OrderNumber;
            return RedirectToAction("Comment");
        }

    }
}