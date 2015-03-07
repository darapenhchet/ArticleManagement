using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArticleManagement.Areas.Admin.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public System.DateTime Ondate { get; set; }

        public UsersModel ByUser { get; set; }
    }

    public class CreateCategoryModel
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public System.DateTime Ondate { get; set; }

        public int ByUser { get; set; }
    }

    public class UpdateCategoryModel
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public System.DateTime Ondate { get; set; }

        public int ByUser { get; set; }
    }

    public class DeleteCategoryModel
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public System.DateTime Ondate { get; set; }

        public int ByUser { get; set; }
    }
}