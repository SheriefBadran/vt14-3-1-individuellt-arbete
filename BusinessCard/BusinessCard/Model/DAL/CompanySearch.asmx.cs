using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;

namespace BusinessCard.Model.DAL
{
    /// <summary>
    /// Summary description for CompanySearch
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class CompanySearch : System.Web.Services.WebService
    {
        [WebMethod]
        public List<string> GetCompanyNames(string nameFragment)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["BusinessCardConnectionString"].ConnectionString;
            List<string> companyNames = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AppSchema.uspGetCompanyNamesAutoComp", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar, 20).Value = nameFragment;

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    int companyNameIndex = reader.GetOrdinal("CompanyName");
                    companyNames.Add(reader.GetString(companyNameIndex));
                }
            }
            return companyNames;
        }
    }
}
