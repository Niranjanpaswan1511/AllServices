using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace AllServices.Models
{
    public class AllDetails
    {
        public DataTable table4 { get; set; }

        public DataTable dt1 { get; set; }

        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email_Id { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public string Re_Password { get; set; }
        public string Email { get; set; }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public string OpeningTime { get; set; }
        public string ClosingTime { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string City_location { get; set; }
        public string Pincode { get; set; }

        public string MobileNumber { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public string Services { get; set; }
        public string DateTime { get; set; }
        public bool IsActive { get; set; }
        public string dupimg { get; set; }
        public int ServiceId { get; internal set; }
        public string ServiceName { get; internal set; }
        public List<AllDetails> Binddisplay { get; set; }

        public DataTable tbl1 { get; set; }
        public string VenorId { get;  set; }

        public string  Description { get; set; }
        public int RatingID { get; set; }
        public string RatingName { get; set; }


        //private int serviceId;
        //private string serviceName;
        //private int id;
        //private string firstName;
        //private string lastName;
        //private string emailId;
        //private string mobile;
        //private string gender;
        //private string password;
        //private string rePassword;
        //private string email;
        //private string shopName;
        //private string address;
        //private string openingTime;
        //private string closingTime;
        //private string state;
        //private string district;
        //private string city;
        //private string cityLocation;
        //private string pincode;
        //private string mobileNumber;
        //private string services;
        //private string dateTime;
        //private bool isActive;
        //private string dupimg;
        //private List<AllDetails> binddisplay;
        //public HttpPostedFileBase image { get; set; }

        //public int Id { get { return this.id; } set { this.id = value; } }
        //public string FirstName { get { return this.firstName; } set { this.firstName = value; } }
        //public string LastName { get { return this.lastName; } set { this.lastName = value; } }
        //public string EmailId { get { return this.emailId; } set { this.emailId = value; } }
        //public string Mobile { get { return this.mobile; } set { this.mobile = value; } }
        //public string Gender { get { return this.gender; } set { this.gender = value; } }
        //public string Password { get { return this.password; } set { this.password = value; } }
        //public string RePassword { get { return this.rePassword; } set { this.rePassword = value; } }
        //public string Email { get { return this.email; } set { this.email = value; } }
        //public string ShopName { get { return this.shopName; } set { this.shopName = value; } }
        //public string Address { get { return this.address; } set { this.address = value; } }
        //public string OpeningTime { get { return this.openingTime; } set { this.openingTime = value; } }
        //public string ClosingTime { get { return this.closingTime; } set { this.closingTime = value; } }
        //public string State { get { return this.state; } set { this.state = value; } }
        //public string District { get { return this.district; } set { this.district = value; } }
        //public string City { get { return this.city; } set { this.city = value; } }
        //public string CityLocation { get { return this.cityLocation; } set { this.cityLocation = value; } }
        //public string Pincode { get { return this.pincode; } set { this.pincode = value; } }
        //public string MobileNumber { get { return this.mobileNumber; } set { this.mobileNumber = value; } }
        //public HttpPostedFileBase Image { get { return this.image; } set { this.image = value; } }
        //public string Services { get { return this.services; } set { this.services = value; } }
        //public string DateTime { get { return this.dateTime; } set { this.dateTime = value; } }
        //public bool IsActive { get { return this.isActive; } set { this.isActive = value; } }
        //public string Dupimg { get { return this.dupimg; } set { this.dupimg = value; } }

        //public int ServiceId { get { return this.serviceId; } set { this.serviceId = value; } }
        //public string ServiceName { get { return this.serviceName; } set { this.serviceName = value; } }
        //public List<AllDetails> Binddisplay { get { return this.binddisplay; } set { this.binddisplay = value; } }






    }
}

