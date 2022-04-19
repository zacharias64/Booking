using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult GetCart()
        {
            // 取得目前購物車
            var Cart = Models.Cart.Operation.GetCurrentCart();
            Cart.AddProduct(1);


            return Content($"目前購物車總共：{Cart.TotalAmount} 元");
        }
    }
}