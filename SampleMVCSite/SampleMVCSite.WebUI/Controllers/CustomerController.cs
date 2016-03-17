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
    public class CustomerController : Controller
    {
        IRepositoryBase<Customer> customers;
        

        public CustomerController(IRepositoryBase<Customer> customers) { 
            
            this.customers = customers;
            
        }
        public ActionResult Index()
        {
            var model = customers.GetAll();
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
        public ActionResult Create(Customer customer)
        {
            customers.Insert(customer);
            customers.Commit();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = customers.GetById(id);
            return View(model);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = customers.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(Customer customer, int? id)
        {
            var model = customers.GetById(id);
            customers.Delete(model);
            customers.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = customers.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            customers.Update(customer);
            customers.Commit();
            return RedirectToAction("Index");
        }
    }
}