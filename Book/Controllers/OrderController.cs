using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Book.Models.Member.MemberModel;

namespace Book.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                Session["NoLogin"] = 1;
                return RedirectToAction("Login", "Member") ;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Day25
        //OrderController 的Index() 定義如何將資料存入訂單資料庫(Order與OrderDetail資料表)，
        //其中順序為先寫入Order後，
        //再寫入OrderDetail。
        public ActionResult Index(Models.Ship model)
        {
            
            
            if (this.ModelState.IsValid)
            {
                //取得目前購物車
                var CurrentCart = Models.Cart.Operation.GetCurrentCart();

                //取得目前登入使用者 Id
                //var UserId = HttpContext.User.Identity.GetUserId();
                var UserId = (string)Session["UserID"];

                using (Models.AllBookEntities1 db = new Models.AllBookEntities1())
                {
                    //建立Order物件
                    var order = new Models.Order()
                    {
                        UserId = UserId,
                        RecieverName = model.RecieverName,
                        RecieverPhone = model.RecieverPhone,
                        RecieverAddress = model.RecieverAddress
                    };


                    // 加入 Order 資料表後，儲存變更
                    db.Order.Add(order);
                    db.SaveChanges();


                    //取得購物車中的 OrderDeatil 物件
                    var orderDetails = CurrentCart.ToOrderDetailList(order.Id);

                    //將 OrderDetails 物件，加入OrderDetail資枓表後，儲存變更。
                    db.OrderDetail.AddRange(orderDetails);
                    db.SaveChanges();
                }
                
                return RedirectToAction("MyOrder", "Order");
            }

            return View();
        }
        public ActionResult MyOrder()
        {
            

            var UserId = (string)Session["UserId"];

            using (Models.AllBookEntities1 db = new Models.AllBookEntities1())
            {
                var result = db.Order
                    .Where(w => w.UserId == UserId)
                    .Select(s => s).ToList();

                return View(result);
            }
        }
        public ActionResult MyOrderDetail(int id)
        {
            using (Models.AllBookEntities1 db = new Models.AllBookEntities1())
            {
                var result = (from s in db.OrderDetail
                              where s.OrderId == id
                              select s).ToList();

                if (result.Count == 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(result);
                }

            }
        }
        

    }
}