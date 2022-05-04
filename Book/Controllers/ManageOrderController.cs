using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book.Controllers
{
    public class ManageOrderController : Controller
    {
        // GET: ManageOrder
        public ActionResult Index()
        {
            using (Models.AllBookEntities1 db = new Models.AllBookEntities1())
            {
                var result = (from s in db.Order select s).ToList();
                return View(result);
            }
        }
        public ActionResult Details(int id)
        { 
            using(Models.AllBookEntities1 db=new Models.AllBookEntities1())
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