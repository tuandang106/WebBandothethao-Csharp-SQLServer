using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;
using WebsiteBanHang.Models;

namespace WebsiteBanHang.Controllers
{
    public class PaymentController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();

        // GET: Payment
        public ActionResult Index()
        {
            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var lstCart = (List<CartModel>)Session["cart"];

                Order objOrder = new Order();
                objOrder.Name = "DonHang-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                objOrder.UserId = int.Parse(Session["idUser"].ToString());
                objOrder.CreatedOnUtc = DateTime.Now;
                objOrder.Status = 1;
                objWebsiteBanHangEntities.Order.Add(objOrder);
                //lấy dữ liệu vào bảng order
                objWebsiteBanHangEntities.SaveChanges();
                //lấy id để lưu vào bảng detail
                int intOrderId = objOrder.Id;

                List<OrderDetail> lstOrderDetail = new List<OrderDetail>();
                foreach (var item in lstCart)
                {
                    OrderDetail obj = new OrderDetail();
                    obj.Quantity = item.Quantity;
                    obj.OrderId = intOrderId;
                    obj.ProductId = item.Product.Id;
                    lstOrderDetail.Add(obj);
                }
                objWebsiteBanHangEntities.OrderDetail.AddRange(lstOrderDetail);
                objWebsiteBanHangEntities.SaveChanges();
            }
            return View();
        }
    }
}