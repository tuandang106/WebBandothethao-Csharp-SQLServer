using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;
using static WebsiteBanHang.Common;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Admin/Product
        public ActionResult Index(string currentFilter,string SearchString, int? page)
        {
            var lstProduct = new List<Product>();
            if(SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                lstProduct = objWebsiteBanHangEntities.Product.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                lstProduct = objWebsiteBanHangEntities.Product.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            //số lượng item của 1 trang = 4
            int pageSize = 4;
            int PageNumber = (page ?? 1);
            //sắp xếp theo id sản phẩm
            lstProduct = lstProduct.OrderByDescending(n => n.Id).ToList();
            return View(lstProduct.ToPagedList(PageNumber,pageSize));
        }
        public ActionResult Details(int Id)
        {
            var objProduct = objWebsiteBanHangEntities.Product.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objProduct = objWebsiteBanHangEntities.Product.Where(n => n.Id == id).FirstOrDefault();

            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Delete(Product objPro)
        {
            var objProduct = objWebsiteBanHangEntities.Product.Where(n => n.Id == objPro.Id).FirstOrDefault();

            objWebsiteBanHangEntities.Product.Remove(objProduct);
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objProduct = objWebsiteBanHangEntities.Product.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct); 
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(int id,Product objProduct)
        {
            if(objProduct.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                fileName = fileName + extension;
                objProduct.Avatar = fileName;
                objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));

            }
            objWebsiteBanHangEntities.Entry(objProduct).State = EntityState.Modified;
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            this.LoadData();
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Product objProduct)
        {
            this.LoadData();
            if(ModelState.IsValid)
            {
                try
                {
                    if(objProduct.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                        //tên
                        string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                        //ảnh
                        fileName = fileName + extension;
                        //ảnh.png
                        objProduct.Avatar = fileName;
                        objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                    }
                    objProduct.CreatedOnUtc = DateTime.Now;
                    objWebsiteBanHangEntities.Product.Add(objProduct);
                    objWebsiteBanHangEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch(Exception)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(objProduct);
        }
        void LoadData()
        {
            Common objCommon = new Common();
            var lstCat = objWebsiteBanHangEntities.Category.ToList();

            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dtCategory = converter.ToDataTable(lstCat);
            ViewBag.ListCategory = objCommon.ToSelectList(dtCategory, "Id", "Name");

            var lstBrand = objWebsiteBanHangEntities.Brand.ToList();
            DataTable dtBrand = converter.ToDataTable(lstBrand);

            ViewBag.ListBrand = objCommon.ToSelectList(dtBrand, "Id", "Name");
            //loại sản phẩm
            List<ProductType> lstProductType = new List<ProductType>();
            ProductType objProductType = new ProductType();
            objProductType.Id = 01;
            objProductType.Name = "Giảm giá sốc";
            lstProductType.Add(objProductType);

            objProductType = new ProductType();
            objProductType.Id = 02;
            objProductType.Name = "Đề xuất";
            lstProductType.Add(objProductType);

            DataTable dtProductType = converter.ToDataTable(lstProductType);

            ViewBag.ProductType = objCommon.ToSelectList(dtProductType, "Id", "Name");
        }
    }
}