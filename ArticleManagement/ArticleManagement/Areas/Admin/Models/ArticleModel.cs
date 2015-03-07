using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace ArticleManagement.Areas.Admin.Models
{
    public class ArticleModel
    {
        [Display(Name= "ID")]
        public int Id { get; set; }

        [Required]
        [StringLength(150, MinimumLength=5)]
        [Display(Name = "Title")]
        public String Title { get; set; }

        [Required]
        [MinLength(5)]
        [Display(Name = "Content")]
        public String Content { get; set; }

        [Display(Name = "Photo")]
        public String Photo { get; set; }

        [Display(Name = "Category")]
        public CategoryModel Category { get; set; }

        [Display(Name = "Date")]
        public String OnDate { get; set; }

        [Display(Name = "User")]
        public UsersModel ByUser { get; set; }

        public String SubString { 
            get {
                return (Content.Length>50)?Content.Substring(0,42)+"...":Content;
            }
        }
    }

    public class DeleteArticleModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 5)]
        [Display(Name = "Title")]
        public String Title { get; set; }

        [Required]
        [MinLength(5)]
        [Display(Name = "Content")]
        public String Content { get; set; }

        [Display(Name = "Photo")]
        public String Photo { get; set; }

        [Display(Name = "Category")]
        public int Category { get; set; }

        [Display(Name = "Date")]
        public String OnDate { get; set; }

        [Display(Name = "User")]
        public int ByUser { get; set; }
    }

    public class UpdateArticleModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 5)]
        [Display(Name = "Title")]
        public String Title { get; set; }

        [Required]
        [MinLength(5)]
        [Display(Name = "Content")]
        public String Content { get; set; }

        [Display(Name = "Photo")]
        public String Photo { get; set; }

        [Display(Name = "Category")]
        public CategoryModel Category { get; set; }

        [Display(Name = "Date")]
        public String OnDate { get; set; }

        [Display(Name = "User")]
        public UsersModel ByUser { get; set; }
    }
}