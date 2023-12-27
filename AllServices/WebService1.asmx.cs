using AllServices.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Runtime.InteropServices;

namespace AllServices
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        string connectionstring = ("Data Source=pc1;Initial Catalog=Allservice;Integrated Security=True");
        public SqlConnection con = new SqlConnection("Data Source = pc1; Initial Catalog = Allservice; Integrated Security = True");
        private string pic;
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat=ResponseFormat.Json)]
        public string Login(string Fname,string LastName)
        {
            LoginDetails lc=new LoginDetails();
            SqlCommand cmd = new SqlCommand("GetLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@Email", Fname);
            cmd.Parameters.AddWithValue("@Password", LastName);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                Session.Timeout = 5;
                Session["UserName"] = Fname;
                return "ok";
            }
            else
            {
                return "Error";
            }
            con.Close();
            


        }
    }
}
