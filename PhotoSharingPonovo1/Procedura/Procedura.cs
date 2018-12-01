using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PhotoSharingPonovo1.Procedura
{
    public class Procedura
    {
        public int Login(string ime, string password)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = @"LoginTestProcTri";
                    cmd.Parameters.AddWithValue("@ime", ime);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.Add("@pov", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        int r;
                        r = (int)cmd.Parameters["@pov"].Value;
                        return r;
                    }
                    catch (Exception ex)
                    {
                        return -1;
                    }
                }
            }
        }
    }
}