using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book.Controllers
{
    public class EditController : Controller
    {
        // GET: Edit
        public ActionResult Index()
        {
            //宣告回傳產品列表result
            List<Models.BookList> result = new List<Models.BookList>();

            //接收轉導的成功訊息(將轉導的成功訊息設定給ViewBag變數)
            ViewBag.ResultMessage = TempData["ResultMessage"];

            //使用CartsEntities類別，名稱為db
            using (Models.AllBookEntities db = new Models.AllBookEntities())
            {
                //使用LinQ語法抓取目前Products資料庫中所有資料
                result = (from s in db.BookList select s).ToList();
            }
            //
            //將 result 傳送給檢視 
            return View(result);
        }

        
    }
}