using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using AllServices.Models;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace AllServices.Models
{
    public class business_layer
    {
        Datalayer dt=new Datalayer();
        public bool reg(AllDetails allDetails)
        {
            dt.regster(allDetails);
            return true;
        }
        public bool vreg(AllDetails Details)
        {
            dt.VendorRegistration(Details);
            return true;
        }



        public AllDetails GetallState()
        {

            DataTable dataTable = dt.Getstate("proc_getstate");
            List<AllDetails> States = new List<AllDetails>();
            foreach (DataRow row in dataTable.Rows)
            {
                AllDetails states = new AllDetails();
                states.Id = Convert.ToInt32(row["State_ID"]);
                states.State = row["State"].ToString();
                States.Add(states);
            }
            AllDetails obj = new AllDetails();
            obj.Binddisplay = States;
            return obj;
        }


        // Get Services Name for DDl


        public AllDetails GetAllServices()
        {
            DataTable dataTable = dt.GetAllServices("[proc_GetSrvicesName]");
            List<AllDetails> service = new List<AllDetails>();
            foreach (DataRow dt in dataTable.Rows)
            {
                AllDetails services1 = new AllDetails();
                services1.ServiceId = (int)dt["id"];
                services1.ServiceName = (string)dt["Services"];
                service.Add(services1);
            }
            AllDetails obj = new AllDetails();
            obj.Binddisplay = service;
            return obj;
        }

        public bool contactus(Contactus contactus) 
        {
          dt.Contact(contactus);
            return true;
        }
        public bool UploadService(AllDetails alDetails)
        {
            dt.uploadservices(alDetails);
            return true;
        }

       

        public AllDetails getdistrictbystate(string state)
        {
            DataTable dataTable = dt.getDistrictByState(state);
            List<AllDetails> District = new List<AllDetails>();
            foreach (DataRow row in dataTable.Rows)
            {
                AllDetails districtobj = new AllDetails();
                districtobj.Id = Convert.ToInt32(row["District_Id"].ToString());
                districtobj.District = row["District"].ToString();
                District.Add(districtobj);
            }
            AllDetails obj = new AllDetails();
            obj.Binddisplay = District;
            return obj;

        }
        public AllDetails getDistrictbyCity(string district)
        {
            DataTable dataTable = dt.getcitybyDistrict(district);
            List<AllDetails> City = new List<AllDetails>();
            foreach (DataRow row in dataTable.Rows)
            {
                AllDetails cityobj = new AllDetails();
                cityobj.Id = Convert.ToInt32(row["cityid"].ToString());
                cityobj.City = row["cityname"].ToString();
                City.Add(cityobj);


            }
            AllDetails obj = new AllDetails();
            obj.Binddisplay = City;
            return obj;
        }

        internal static object GetPropertyType()
        {
            throw new NotImplementedException();
        }


        public DataSet GetDataList(string id,string procName)
        {
            DataSet dataSet = new DataSet();
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Id",id)
            };
            dataSet=dt.ExeProcDataset(procName, sp);
            return dataSet;
        
        }

        public  DataSet GetDataUsingParameter(string id, string ProcName)
        {
            DataSet set = new DataSet();
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("id",id)
            };
            set=dt.ExeProcDataset(ProcName, sqlParameter);
            return set;
        }
    }
}