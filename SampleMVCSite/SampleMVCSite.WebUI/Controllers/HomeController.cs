using System.Web.Mvc;
using SampleMVCSite.Contracts.Repositories;
using SampleMVCSite.Contracts.Data;
using SampleMVCSite.Models;


namespace SampleMVCSite.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryBase<Customer> customers;
        IRepositoryBase<Product> products;

        public HomeController(IRepositoryBase<Customer> customers, IRepositoryBase<Product> products) { 
            
            this.customers = customers;
            this.products = products;
        }
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}