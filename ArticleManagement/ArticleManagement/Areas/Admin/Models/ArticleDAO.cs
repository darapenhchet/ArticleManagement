using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ArticleManagement.Areas.Admin.Models
{
    public class ArticleDAO
    {
        private static String cs = "Data Source=LOCALHOST; Initial Catalog=AssigmentDB; Integrated Security=True; Pooling=False";
        
        public List<ArticleModel> ListAllArticles(String Title="")
        {
            try
            {
                List<ArticleModel> list = new List<ArticleModel>();
                String sql = @"SELECT Articles.ID, Title,Content,Photo, Name, Articles.OnDate, users.Lastname, users.Firstname FROM Articles
                               INNER JOIN Users 
                               ON Articles.ByUser = Users.Id
                               INNER JOIN Categories
                               ON Articles.Category = Categories.id WHERE title LIKE '%" + Title + "%'";
                DataSet ds = new DataSet();
                ds = DB.Query(sql);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ArticleModel article = new ArticleModel();
                    article.Id = (int)ds.Tables[0].Rows[i]["Id"];
                    article.Title = ds.Tables[0].Rows[i]["Title"].ToString();
                    article.Content = ds.Tables[0].Rows[i]["Content"].ToString();
                    article.Photo = ds.Tables[0].Rows[i]["Photo"].ToString();
                    //article.Category =(int) ds.Tables[0].Rows[i]["Category"];
                    article.OnDate = ds.Tables[0].Rows[i]["OnDate"].ToString();
                    CategoryModel category = new CategoryModel();
                    category.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    UsersModel user = new UsersModel();
                    user.LastName = ds.Tables[0].Rows[i]["Lastname"].ToString();
                    user.FirstName = ds.Tables[0].Rows[i]["Firstname"].ToString();
                    article.ByUser = user;
                    article.Category = category;
                    list.Add(article);
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public ArticleModel GetArticle(int id)
        {
            ArticleModel article = new ArticleModel();
            SqlDataReader dr;
            String sql = @"SELECT Articles.ID, Title,Content,Photo, Name,Articles.OnDate, users.Lastname, users.Firstname 
                               FROM Articles
                               INNER JOIN Users 
                               ON Articles.ByUser = Users.Id
                               INNER JOIN Categories
                               ON Articles.Category = Categories.id WHERE Articles.ID = " + id;
            
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
                            article.Id = (int)dr["Id"];
                            article.Title = dr["Title"].ToString();
                            article.Content = dr["Content"].ToString();
                            article.OnDate = dr["OnDate"].ToString();
                            CategoryModel category = new CategoryModel();
                            category.Name = dr["Name"].ToString();
                            article.Category = category;
                            UsersModel user = new UsersModel();
                            user.FirstName = dr["Firstname"].ToString();
                            user.LastName = dr["Lastname"].ToString();
                            article.ByUser = user;
                        }
                        return article;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public Boolean UpdateArticle(UpdateArticleModel article)
        {
            try
            {

                String sql = @"UPDATE Articles SET Title=@p1, Content=@p2, Category=@p3 
                           WHERE Id = @p4";

                return DB.Action(sql, article.Title, article.Content, article.Category.Id, article.Id);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return false;
            }
        }

        public Boolean CreateArticle(ArticleModel article)
        {
            try
            {

                String sql = @"INSERT Articles(Title,Content,Category,ByUser,Photo) 
                           VALUES(@p1,@p2,@p3,@p4,@p5)";
                UsersModel user = new UsersModel();
                user = (UsersModel)HttpContext.Current.Session["USER"];
                return DB.Action(sql, article.Title, article.Content, article.Category.Id,user.Id,"PHOTO");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return false;
            }
        }

        public Boolean DeleteArticle(int id)
        {
            try
            {
                String sql = @"DELETE FROM Articles WHERE ID = @p1";
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