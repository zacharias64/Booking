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
            using (Models.AllBookEntities1 db = new Models.AllBookEntities1())
            {
                //使用LinQ語法抓取目前Products資料庫中所有資料
                result = (from s in db.BookList select s).ToList();
            }
            //
            //將 result 傳送給檢視 
            return View(result);
        }
        public ActionResult Create()
        {
            return View();
        }

        //建立商品頁面—資料傳回處理
        [HttpPost] //指定只有使用POST方法才可進入
        public ActionResult Create(Models.BookList postback)
        {

            /*判斷如果Product資料驗證通過，則設定成功訊息至TempData，並且轉導致Index頁面。 */

            //如果資料驗証成功
            if (this.ModelState.IsValid)

                using (Models.AllBookEntities1 db = new Models.AllBookEntities1())
                {
                    //將回傳資料 postback加入至products
                    db.BookList.Add(postback);

                    //儲存異動資料
                    db.SaveChanges();

                    //設定成功訊息
                    TempData["ResultMessage"] = String.Format($"商品[{postback.bTitle}]成功建立");

                    //轉導product/Index頁面
                    return RedirectToAction("Index");
                }

            //失敗訊息
            ViewBag.ResultMessage = "資料有誤，請檢查";

            //停留在Create頁面
            return View(postback);
        }
        public ActionResult Edit(int id)
        {
            using (Models.AllBookEntities1 db = new Models.AllBookEntities1())
            {
                //抓取product.Id等於輸入id的資料
                var result = (from s in db.BookList where s.bId == id select s).FirstOrDefault();

                //判斷此id是否有資料
                if (result != default(Models.BookList))
                {
                    //如果有，回傳編輯商品頁面
                    return View(result);
                }
                else
                {
                    //如果沒有資料，則顯示資料錯誤訊息，並導回Index頁面
                    TempData["resultMessage"] = "資料有誤，請重新操作";
                    return RedirectToAction("Index");
                }
            }
        }


        //編輯商品頁面—資料傳回處理
        [HttpPost]
        /*由於原本Index頁面的Delete按鈕是使用Get操作，此將Delete()方法改為Post，所以伺服器找不到相對應的方法而產生錯誤。
         故須到Index頁面，
         將原本使用ActionLink的刪除按鈕改為使用BeginForm*/
        public ActionResult Edit(Models.BookList postback)
        {
            //判斷使用者輸入資料是否正確
            if (this.ModelState.IsValid)
            {
                using (Models.AllBookEntities1 db = new Models.AllBookEntities1())
                {
                    //抓取Product.Id等於回傳postback.ID的資枓
                    var result = (from s in db.BookList where s.bId == postback.bId select s).FirstOrDefault();

                    //儲存使用者變更資料 
                    result.bTitle = postback.bTitle;
                    result.bOriginal = postback.bOriginal;
                    result.bAuthor = postback.bAuthor;
                    result.bYear = postback.bYear;
                    result.bPubHouse = postback.bPubHouse;
                    result.bISBN = postback.bISBN;
                    result.bMoney = postback.bMoney;
                    result.bLaun = postback.bLaun;
                    result.bIntroduce = postback.bIntroduce;
                    result.bURL = postback.bURL;
                    result.bQuan = postback.bQuan;

                    //儲存所有變更
                    db.SaveChanges();

                    //設定成功訊息並導回index頁面
                    TempData["ResultMessage"] = String.Format($"商品[{postback.bTitle}]成功編輯");
                    return RedirectToAction("Index");

                }
            }

            else
            {
                return View(postback);
            }

        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (Models.AllBookEntities1 db = new Models.AllBookEntities1())
            {
                
                var result = (from s in db.BookList where s.bId == id select s).FirstOrDefault();

                if (result != default(Models.BookList))
                {
                    db.BookList.Remove(result);
                    db.SaveChanges();
                    TempData["ResultMessage"] = String.Format($"商品[{result.bTitle}]成功刪除");
                    return RedirectToAction("Index");
                }

                else
                {
                    TempData["resultMessage"] = "指定資料不存在，無法刪除，請重新操作";
                    return RedirectToAction("Index");
                }
            }
        }


    }
}