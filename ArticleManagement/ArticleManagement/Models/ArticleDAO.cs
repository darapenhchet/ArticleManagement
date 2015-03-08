using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace Assignment.Areas.Admin.Models
{
    public class ArticleDAO
    {
        public static bool Create(SetPost p)
        {
            string sql = @"INSERT INTO [dbo].[Articles] ([Title], [Content], [Photo], [Category], [ByUser])  VALUES (@p1, @p2, @p3, @p4, @p5)";
            return DB.Action(sql, p.Title, p.Content, p.Photo, p.Category, AccountDAO.Id);
        }

        public static GetPost Detail(int id) {
            string sql = @"SELECT Articles.ID, Title, Content, Category, Articles.ByUser, Name, Articles.OnDate, Firstname, Lastname, Photo 
                           FROM [dbo].[Articles] 
                           INNER JOIN Users ON Users.Id = Articles.ByUser 
                           INNER JOIN Categories ON Categories.Id = Articles.Category
                           WHERE Articles.Id = @p1";
            DataSet ds = DB.Query(sql, id);
            return DB.GetPostDS(ds);
        }

        public static bool Update(UpdatePost p)
        {
            //string sql = @"UPDATE [dbo].[Articles] SET [Title] = @p1, [Content] = @p2, [Photo] = @p3, [Category] = @p4, [byUser] = @p5, [OnDate] = @p6 WHERE Id = @p7";
            //return DB.Action(sql, p.Title, p.Content, p.Photo, p.Category, p.ByUser, p.OnDate, p.Id);
            string sql = @"UPDATE [dbo].[Articles] SET [Title] = @p1, [Content] = @p2, [byUser] = @p3, [OnDate] = @p4 WHERE Id = @p5";
            return DB.Action(sql, p.Title, p.Content, p.ByUser, p.OnDate, p.Id);
        }

        public static bool Delete(int id)
        {
            string sql = @"DELETE [dbo].[Articles] WHERE Id = @p1";
            return DB.Action(sql, id);
        }

        public static GetCategory CategoryBy(int id)
        {
            string sql = @"SELECT Name FROM [dbo].[Categories] WHERE Id = @p1";
            DataSet ds = DB.Query(sql, id);
            return DB.GetCategoryDS(ds);
        }

        public static List<GetPost> List()
        {
            string sql = @"SELECT Articles.ID, Title, Content, Category, Articles.ByUser, Name, Articles.OnDate, Firstname, Lastname, Photo 
                           FROM [dbo].[Articles] 
                           INNER JOIN Users ON Users.Id = Articles.ByUser 
                           INNER JOIN Categories ON Categories.Id = Articles.Category";
            DataSet ds = DB.Query(sql);
            return DB.GetAllPostDS(ds);
        }

    }
}