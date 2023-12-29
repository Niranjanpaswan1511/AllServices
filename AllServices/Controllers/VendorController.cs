using AllServices.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
        [HttpPost]

        public ActionResult VendorLogin(AllDetails d)
        {
           Datalayer k=new Datalayer();
           DataTable dt= business_Layer.VendorLogin(d, "VendorLogin");
            if (dt != null)
            {
                Session["UserName"]=d.Email.ToString();
                foreach (DataRow dr in dt.Rows)
                {
                    Session["Id"] = dr["Id"].ToString();

                }
                return RedirectToAction("DashBoard");
            }

           return View();
        }

        


        public ActionResult DashBoard()
        {
            if (Session["UserName"]!= null)
            {
                string i = (string)Session["Id"];

                string Total = business_Layer.TotalUploadServices(i, "ToTalUploadServices");
                ViewBag.total = Total;

                DataTable dt = new DataTable();
                dt = business_Layer.GetListofServices(i);
                AllDetails ald = new AllDetails();
                if (dt.Rows.Count > 0)
                {

                    ald.table4 = dt;

                }


                return View(ald);
            }
            else
            {
                return RedirectToAction("VendorLogin");
            }
        
        }


        public ActionResult Logout()
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return View("VendorLogin");
           
        }

        public ActionResult ViewList()
        {
            return View();
        }

    }
}