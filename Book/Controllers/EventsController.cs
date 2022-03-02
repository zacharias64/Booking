using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using Book.Models;

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
            //string  Book1OrderNumber= Request["Many1"].ToString();

            var number = Convert.ToInt32(Request["Many1"]);

            Session["Book1Number"] = number;

            var model = (Buying)Session["BookListId"];

            if (model.BookListId.Contains(number) != true)
            {
                model.BookListId.Add(number);
            }

            Session["BookListId"] = model;


            functionQQQ();

            return RedirectToAction("Comment");
        }
        public ActionResult Order1()
        {
            var number = Convert.ToInt32(Request["Many2"]);

            Session["Book1Number"] = number;

            var model = (Buying)Session["BookListId"];

            if (model.BookListId.Contains(number) != true)
            {
                model.BookListId.Add(number);
            }

            Session["BookListId"] = model;

            return RedirectToAction("Comment");
        }

        private void functionQQQ()
        {
            var a = 0;
        }

    }
}