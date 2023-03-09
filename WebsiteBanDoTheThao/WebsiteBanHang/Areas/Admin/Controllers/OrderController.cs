using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Admin/Product
        // GET: Admin/Order
        public ActionResult Index()
        {
            var lstOrder = objWebsiteBanHangEntities.Order.ToList();
            return View(lstOrder);
        }
    }
}