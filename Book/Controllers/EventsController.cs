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

        public ActionResult BookIntro(int Id)
        {
            //ViewBag.Id = Id;
            // get data from db by parameter id

            ViewBag.BookId = new FakeDB().GetBook(Id).bId;
            ViewBag.BookTitle = new FakeDB().GetBook(Id).bTitle;
            ViewBag.BookOriginal = new FakeDB().GetBook(Id).bOriginal;
            ViewBag.BookYear = new FakeDB().GetBook(Id).bYear;
            ViewBag.BookAuthor = new FakeDB().GetBook(Id).bAuthor;
            ViewBag.BookPubHouse = new FakeDB().GetBook(Id).bPubHouse;
            ViewBag.BookISBN = new FakeDB().GetBook(Id).bISBN;
            ViewBag.BookTrans = new FakeDB().GetBook(Id).bTrans;
            ViewBag.BookMoney = new FakeDB().GetBook(Id).bMoney;
            ViewBag.BookLaun = new FakeDB().GetBook(Id).bLaun;
            ViewBag.BookIntroduce = new FakeDB().GetBook(Id).bIntroduce;
            ViewBag.BookPic = new FakeDB().GetBook(Id).bPic;

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
            var money = 299;
            Session["Book1Number"] = number;
            Session["Book1Money"]= number*money;
            var model = (Buying)Session["BookListId"];

            if (model.BookListId.Contains(number) != true)
            {
                model.BookListId.Add(number);
            }

            Session["BookListId"] = model;

            return RedirectToAction("Comment");
        }
        public ActionResult Order1()
        {
            var number = Convert.ToInt32(Request["Many2"]);
            var money = 279;
            Session["Book2Money"] = number * money;
            Session["Book2Number"] = number;

            var model = (Buying)Session["BookListId"];

            if (model.BookListId.Contains(number) != true)
            {
                model.BookListId.Add(number);
            }

            Session["BookListId"] = model;

            return RedirectToAction("Comment");
        }

        

    }
}