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
    public class OrderController : Controller
    {
        IRepositoryBase<Order> orders;


        public OrderController(IRepositoryBase<Order> orders){
      
            this.orders = orders;
            
        }
        public ActionResult Index()
        {
            var model = orders.GetAll();
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
        public ActionResult Create(Order order)
        {
            orders.Insert(order);
            orders.Commit();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = orders.GetById(id);
            return View(model);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = orders.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(Order order, int? id)
        {
            var model = orders.GetById(id);
            orders.Delete(model);
            orders.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = orders.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Order order)
        {
            orders.Update(order);
            orders.Commit();
            return RedirectToAction("Index");
        }
    }
}