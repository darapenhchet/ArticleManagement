using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Assignment.Areas.Admin.Models
{
    public class CategoryDAO
    {
        public static bool Create(SetCategory c)
        {
            string sql = @"INSERT INTO [dbo].[Categories] ([Name], [Description], [ByUser])  VALUES (@p1, @p2, @p3)";
            return DB.Action(sql, c.Name, c.Description, AccountDAO.Id);
        }

        public static GetCategory Detail(int id)
        {
            string sql = @"SELECT * FROM [dbo].[Categories] WHERE Id = @p1";
            DataSet ds = DB.Query(sql, id);
            return DB.GetCategoryDS(ds);
        }

        public static bool Delete(int id)
        {
            string sql = @"DELETE [dbo].[Categories] WHERE Id = @p1";
            return DB.Action(sql, id);
        }

        public static bool Update(SetCategory c)
        {
            string sql = @"UPDATE [dbo].[Categories] SET [Name] = @p1, [Description] = @p2, [ByUser] = @p3, [OnDate] = @p4 WHERE Id = @p5";
            return DB.Action(sql, c.Name, c.Description, c.ByUser, c.OnDate, c.Id);
        }

        public static List<GetCategory> List(){
             string sql = @"SELECT * FROM [dbo].[Categories]";
            DataSet ds = DB.Query(sql);
            return DB.GetAllCategoryDS(ds);
        }

    }
}