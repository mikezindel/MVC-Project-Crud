using SampleMVCSite.Contracts.Repositories;
using SampleMVCSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SampleMVCSite.WebUI.Controllers
{
    public class ProductController : Controller
    {
        
        IRepositoryBase<Product> products;

        public ProductController(IRepositoryBase<Product> products)
        {

            
            this.products = products;
        }
        public ActionResult Index()
        {
            var model = products.GetAll();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            products.Insert(product);
            products.Commit();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = products.GetById(id);
            return View(model);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = products.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(Product product, int? id)
        {
            var model = products.GetById(id);
            products.Delete(model);
            products.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = products.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            products.Update(product);
            products.Commit();
            return RedirectToAction("Index");
        }
    }
}