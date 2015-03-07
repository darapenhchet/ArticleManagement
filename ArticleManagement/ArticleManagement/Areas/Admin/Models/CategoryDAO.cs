using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ArticleManagement.Areas.Admin.Models
{
    public class CategoryDAO
    {
        private static String cs = "Data Source=LOCALHOST; Initial Catalog=AssigmentDB; Integrated Security=True; Pooling=False";

        public List<CategoryModel> ListAllCategories(String name = "")
        {
            try
            {
                String sql = @"SELECT C.Id, C.Name,C.Description, C.OnDate,C.ByUser,U.Firstname,U.Lastname FROM Categories C
                               LEFT JOIN Users U ON U.Id = C.ByUser WHERE C.name LIKE '%" + name + "%'";
                List<CategoryModel> list = new List<CategoryModel>();
                DataSet ds = new DataSet();
                ds = DB.Query(sql);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    CategoryModel category = new CategoryModel();
                    category.Id = (int)ds.Tables[0].Rows[i]["Id"];
                    category.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    category.Description = ds.Tables[0].Rows[i]["Description"].ToString();
                    category.Ondate = (System.DateTime)ds.Tables[0].Rows[i]["OnDate"];
                    UsersModel user = new UsersModel();
                    user.FirstName = ds.Tables[0].Rows[i]["FirstName"].ToString();
                    user.LastName = ds.Tables[0].Rows[i]["LastName"].ToString();
                    category.ByUser = user;
                    list.Add(category);
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public CategoryModel GetCategory(int id)
        {
            CategoryModel category = new CategoryModel();
            SqlDataReader dr;
            String sql = @"SELECT C.Id, C.Name,C.Description, C.OnDate,C.ByUser,U.Firstname,U.Lastname FROM Categories C
                               LEFT JOIN Users U ON U.Id = C.ByUser WHERE C.ID ="+id;

            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        con.Open();
                        command.CommandText = sql;
                        command.Connection = con;
                        dr = command.ExecuteReader();
                        while (dr.Read())
                        {
                            category.Id = (int)dr["Id"];
                            category.Name = dr["Name"].ToString();
                            category.Description = dr["Description"].ToString();
                            category.Ondate = (System.DateTime)dr["OnDate"];
                            UsersModel user = new UsersModel();
                            user.FirstName = dr["Firstname"].ToString();
                            user.LastName = dr["Lastname"].ToString();
                            category.ByUser = user;
                        }
                        return category;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public Boolean CreateCategory(CreateCategoryModel category)
        {
            try
            {
                String sql = @"INSERT INTO Categories(Name, Description, ByUser) VALUES(@p1,@p2,@p3)";
                UsersModel user = (UsersModel)HttpContext.Current.Session["USER"];
                return DB.Action(sql,category.Name,category.Description,user.Id);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return false;
            }
        }

        public Boolean UpdateCategory(UpdateCategoryModel category)
        {
            try
            {
                String sql = @"UPDATE Categories SET Name = @p1, Description =@p2 WHERE Id=@p3";
                return DB.Action(sql, category.Name, category.Description, category.Id);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return false;
            }
        }

        public Boolean DeleteCategory(int id)
        {
            try
            {
                String sql = @"DELETE FROM Categories WHERE ID=@p1";
                return DB.Action(sql, id);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return false;
            }
        }
    }
}