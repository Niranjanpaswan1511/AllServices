using AllServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;


namespace AllServices.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection("Data Source=pc1;Initial Catalog=Allservice;Integrated Security=True");

        business_layer business_Layer = new business_layer();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register(AllDetails allDetails)
        {
            business_Layer.reg(allDetails);
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginDetails lc)
        {
            SqlCommand cmd = new SqlCommand("GetLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@Email", lc.UserName);
            cmd.Parameters.AddWithValue("@Password", lc.Password);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                Session.Timeout = 5;
                Session["UserName"] = lc.UserName.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Message"] = "Login Failed!";
            }
            con.Close();
            return View();
        }
        [HttpGet]
        public ActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContactUs(Contactus contactus)
        {
            business_Layer.contactus(contactus);
            return View();
            

        }
        public ActionResult opne()
        {
            return View();
        }
        public ActionResult Allservices()
        {
            return View();
        }
        [HttpGet]
       public ActionResult UploadServices()
        {
            ViewBag.uploadservices=business_Layer.GetallState();
            ViewBag.GetSevicesName = business_Layer.GetAllServices();

            return View();
        }
        [HttpPost]
        public ActionResult UploadServices(AllDetails ad)
        {
            string filename = Path.GetFileName(ad.Image.FileName);
            string filepath = Path.Combine(Server.MapPath("~/Servepic"), filename);
            ad.Image.SaveAs(filepath);
            ad.dupimg = filename;
           bool b= business_Layer.UploadService(ad);
            if(b)
            {
                Response.Write("UploadService is Succsefull");
            }
            else
            {
                Response.Write("UploadService is not Succsefull");
            }


            return RedirectToAction("UploadServices");
        }


        public ActionResult getdistrictbystate(string state)
        {
            AllDetails district = business_Layer.getdistrictbystate(state);
            return Json(district, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getCitybyDistrict(string district)
        {
            AllDetails city = business_Layer.getDistrictbyCity(district);
            return Json(city, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetList(string id)
        {
            AllDetails a=new AllDetails();
            DataSet dataSet = new DataSet();
            dataSet = business_Layer.GetDataList(id, "GetDataList");
            if(dataSet != null)
            {
                a.tbl1 = dataSet.Tables[0];
            }
            return View(a);
        }


        public ActionResult SigalView(string id)
        {
            if (Session["UserName"]!=null)
            {
                AllDetails a = new AllDetails();
                DataSet dataSet=new DataSet();
                dataSet = business_Layer.GetDataUsingParameter(id, "GetDataUsingParamter");
                if(dataSet != null)
                {
                    a.dt1 = dataSet.Tables[0];  
                }
                return View(a);
            }
            else
            {
                return RedirectToAction("login");
            }
        
        }


    }
}