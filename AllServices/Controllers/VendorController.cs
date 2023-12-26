using AllServices.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllServices.Controllers
{
    public class VendorController : Controller
    {
        // GET: Vendor
        SqlConnection con = new SqlConnection("Data Source=pc1;Initial Catalog=Allservice;Integrated Security=True");

        business_layer business_Layer = new business_layer();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult VendorRegistration()
        {

            ViewBag.uploadservices = business_Layer.GetallState();
            return View();
        }
        [HttpPost]
        public ActionResult VendorRegistration(AllDetails details)
        {
            business_Layer.vreg(details);

            return RedirectToAction( "VendorRegistration", "Vendor") ;
        }
        public ActionResult VendorLogin()
        {
            return View();
        }
        public ActionResult demo()
        {
                return View();
        }
    }
}