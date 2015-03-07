using System;       
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ArticleManagement.Areas.Admin.Models
{
    public class DB
    {
        private static String cs = "Data Source=LOCALHOST; Initial Catalog=AssigmentDB; Integrated Security=True; Pooling=False";

        public static String ConnectionString { get; set; }

        public static bool Action(String sql, params Object[] fields)
        {
            try{

                using (SqlConnection con = new SqlConnection(cs))
                {
                    using(SqlCommand cmd = new SqlCommand()){

                        con.Open();
                        cmd.CommandText = sql;
                        cmd.Connection = con;

                        int i = 1;
                        foreach (var field in fields)
                        {
                            cmd.Parameters.AddWithValue("@p" + i, field);
                            i++;
                        }
                        if (cmd.ExecuteNonQuery() != 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }catch(SqlException ex){
                Console.WriteLine(ex);
            }
            return false;
        }

        public static DataSet Query(String sql, params Object[] fields)
        {
            DataSet dataset = new DataSet();
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    con.Open();
                    cmd.CommandText = sql;
                    cmd.Connection = con;

                    int i = 1;
                    foreach (var field in fields)
                    {
                        cmd.Parameters.AddWithValue("@p" + i, field);
                        i++;
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataset);
                        return dataset;
                    }
                }
            }
        }
    }
}