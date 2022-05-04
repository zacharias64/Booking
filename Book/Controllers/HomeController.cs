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
        //public ActionResult Index()
        //{
        //    ViewBag.place = "下列書籍";

        //    var model = new Buying();

        //    model.BookListId = new List<int>();

        //    Session["BookListId"] = model;

        //    return View();
        //}
        public ActionResult Index()
        {
            // GET: Entity
            //宣告回傳商品列表result
            List<Models.BookList> results = new List<Models.BookList>();
            //使用CartsEntity類別 名稱玩db
            using (Models.AllBookEntities1 db = new Models.AllBookEntities1())
            {
                //使用Linq抓取目前Products資料庫的所有資料
                results = (from s in db.BookList select s).ToList();
                //將result回傳給檢視
                return View(results);
            }
        }
        public ActionResult Details(int? id)
        {
            using (Models.AllBookEntities1 db = new Models.AllBookEntities1())
            {
                var result = (from s in db.BookList
                              where s.bId == id
                              select s).FirstOrDefault();

                if (result == default(Models.BookList))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(result);
                }
            }
        }




        public ActionResult About()
        {
            List<Models.BookList> results = new List<Models.BookList>();
            //使用CartsEntity類別 名稱玩db
            using (Models.AllBookEntities1 db = new Models.AllBookEntities1())
            {
                //使用Linq抓取目前Products資料庫的所有資料
                results = (from s in db.BookList select s).ToList();
                //將result回傳給檢視
                return View(results);
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}