using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AllServices.Models;
using System.Data;

using System.Xml.Linq;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using System.Web.Mvc;
using System.Net.Http.Headers;
using MySqlX.XDevAPI;

namespace AllServices.Models
{
    public class Datalayer
    {
        public int VenderId;

       string connectionstring=("Data Source=pc1;Initial Catalog=Allservice;Integrated Security=True");
        public SqlConnection con = new SqlConnection("Data Source = pc1; Initial Catalog = Allservice; Integrated Security = True");
        private string pic;

        private DataTable executeProcedureForDataTableWithOutParameter(string procedureName, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null && parameters.Length > 0)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    DataTable dataTable = new DataTable();

                    connection.Open();

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                    }

                    return dataTable;
                }
            }
        }


        public bool regster(AllDetails reg)
        {
            {
                SqlConnection con = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand("usp_InsertRegistration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@First_Name", reg.First_Name);
                cmd.Parameters.AddWithValue("@Last_Name", reg.Last_Name);
                cmd.Parameters.AddWithValue("@Email_Id", reg.Email);
                cmd.Parameters.AddWithValue("@Mobile", reg.Mobile);
                cmd.Parameters.AddWithValue("@Password", reg.Password);
                cmd.Parameters.AddWithValue("@Re_Password", reg.Re_Password);
                cmd.Parameters.AddWithValue("@DateTime",DateTime.Now);
                cmd.Parameters.AddWithValue("@IsActive", 1);
              
                con.Open();
                int i=cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    return true;
                }
                else 
                { 
                    return false;
                }

            }
        }

        



        public bool VendorRegistration(AllDetails vreg)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    using (SqlCommand cmd = new SqlCommand("InsertVendorRegistration", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@First_Name", vreg.First_Name);
                        cmd.Parameters.AddWithValue("@Last_Name", vreg.Last_Name);
                        cmd.Parameters.AddWithValue("@Email_Id", vreg.Email_Id);
                        cmd.Parameters.AddWithValue("@Mobile", vreg.Mobile);
                        cmd.Parameters.AddWithValue("@Gender", vreg.Gender);
                        cmd.Parameters.AddWithValue("@State", vreg.State);
                        cmd.Parameters.AddWithValue("@District", vreg.District);
                        cmd.Parameters.AddWithValue("@City_location", vreg.City_location);
                        cmd.Parameters.AddWithValue("@Pincode", vreg.Pincode);
                        cmd.Parameters.AddWithValue("@Password", vreg.Password);
                        cmd.Parameters.AddWithValue("@Re_Password", vreg.Re_Password);
                        cmd.Parameters.AddWithValue("@DateTime", DateTime.Today);
                        cmd.Parameters.AddWithValue("@IsActive", 1);
                        conn.Open();
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            Console.WriteLine("Vendor registration successful!");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Vendor registration failed. Please try again.");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }


        public bool Contact(Contactus contactus) 
        {
            {
               SqlConnection conn = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand("INSERT_CONTACT", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", contactus.Name);
                cmd.Parameters.AddWithValue("@Email", contactus.Email);
                cmd.Parameters.AddWithValue("@Mobile", contactus.Mobile);
                cmd.Parameters.AddWithValue("@Message", contactus.Message);
                cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
                cmd.Parameters.AddWithValue("@IsActive", 1);

                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    
                    return true;
                }
                else
                {
                    return false;
                }
                conn.Close();
            }
        }

        internal DataTable GetAllServices(string procedure)
        {
            SqlParameter[] pr = new SqlParameter[0];
            return executeProcedureForDataTableWithOutParameter(procedure, pr);
        }

        internal DataTable GetAllRating(string procedure)
        {
            SqlParameter[] pr=new SqlParameter[0];
            return executeProcedureForDataTableWithOutParameter(procedure, pr);
        }

        internal DataTable Getstate(string procedure)
        {
            SqlParameter[] par = new SqlParameter[0];
            return executeProcedureForDataTableWithOutParameter(procedure, par);
        }

        internal DataTable getDistrictByState(string state)
        {
            return executeProcedureForDataTableWithParameter("proc_district", state);
        }
        public DataTable executeProcedureForDataTableWithParameter(string procedure, string state)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                using (SqlCommand cmd = new SqlCommand(procedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@stateid", state);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }

                conn.Close();
            }

            return dt;
        }

        internal DataTable getcitybyDistrict(string district)
        {

            return executeProcedureForDataTableWithparameter("proc_city", district);
        }

        public DataTable executeProcedureForDataTableWithparameter(string procedure, string district)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                using (SqlCommand cmd = new SqlCommand(procedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@districtid", district);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }
                conn.Close();
            }
            return dataTable;
        }

        public bool uploadservices(AllDetails  ad )
        {
           
        


            SqlConnection con = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand("Proc_UploadServices", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ShopName", ad.ShopName);
                cmd.Parameters.AddWithValue("@State", ad.State);
                cmd.Parameters.AddWithValue("@District", ad.District);
                cmd.Parameters.AddWithValue("@City", ad.City);
                cmd.Parameters.AddWithValue("@OpeningTime", ad.OpeningTime);
                cmd.Parameters.AddWithValue("@ClosingTime", ad.ClosingTime);
                cmd.Parameters.AddWithValue("@MobileNumber", ad.MobileNumber);
                cmd.Parameters.AddWithValue("@Image",ad.dupimg);
                cmd.Parameters.AddWithValue("@Services", ad.Services);
                cmd.Parameters.AddWithValue("@VendorId",ad.VenorId);
                cmd.Parameters.AddWithValue("@IsActive", 1);
                cmd.Parameters.AddWithValue("@RatingID", ad.RatingID);
                cmd.Parameters.AddWithValue("@Description", ad.Description);



                con.Open();
                int i=cmd.ExecuteNonQuery();
                if (i > 0)
                {
               
                return true;
                }
                else
                {
                    return false;
                }
                con.Close();
            }



        public DataSet ExeProcDataset(string procName, SqlParameter[] parameters)
        {
           DataSet ds = new DataSet();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(procName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter param in parameters)
                {
                    cmd.Parameters.Add(param);
                }
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);

            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            return ds;

        }

        public DataTable ExecProcDataTAble(string procName, SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd=new SqlCommand(procName, con);
                cmd.CommandType= CommandType.StoredProcedure;
                foreach(SqlParameter param in parameters)
                {
                    cmd.Parameters.Add(param);
                }
                SqlDataAdapter adp=new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception)
            {

                throw;
            }
            finally { 
                con.Close();
            }
            return dt;  
        }



        }


    








    }



