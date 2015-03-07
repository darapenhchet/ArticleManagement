using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ArticleManagement.Areas.Admin.Models
{
    public class UsersModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Username")]
        public String Username { get; set; }

        [Display(Name = "Password")]
        public String Password { get; set; }

        [Display(Name = "Firstname")]
        public String FirstName { get; set; }

        [Display(Name = "Lastname")]
        public String LastName { get; set; }

        [Display(Name = "Email")]
        public String Email { get; set; }

        [Display(Name = "Address")]
        public String Address { get; set; }
        
        [Display(Name = "Photo")]
        public String Photo { get; set; }
    }

    public class CreateUserModel
    {

        [Required(ErrorMessage="You must enter the username.")]
        [Display(Name = "Username")]
        public String Username { get; set; }

        [Required(ErrorMessage="You must enter the password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public String Password { get; set; }

        [Required(ErrorMessage="You must enter the confirm password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The Password and Confirmation Password are not match...")]

        [StringLength(250, MinimumLength = 2)]
        public String Address { get; set; }

        [Required(ErrorMessage="You must enter the email.")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(150, MinimumLength = 11)]
        public String Email { get; set; }

        [Required(ErrorMessage="You must enter the firstname.")]
        [Display(Name = "Firstname")]
        public String FirstName { get;set;}

        [Required(ErrorMessage="You must enter the lastname.")]
        [Display(Name = "Lastname")]
        public String Lastname { get; set; }

    }

    public class UpdateUserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage="You must enter the username.")]
        [Display(Name = "Username")]
        public String Username { get; set; }

        [Display(Name = "Address")]
        [StringLength(250, MinimumLength = 2)]
        public String Address { get; set; }

        [Required(ErrorMessage="You must enter the email.")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(150, MinimumLength = 11)]
        public String Email { get; set; }

        [Required(ErrorMessage="You must enter the firstname.")]
        [Display(Name = "Firstname")]
        public String FirstName { get;set;}

        [Required(ErrorMessage="You must enter the lastname.")]
        [Display(Name = "Lastname")]
        public String Lastname { get; set; }

    }

    public class DeleteUserModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
    }

    public class SignInModel
    {
        [Required(ErrorMessage = "You must enter the username.")]
        [Display(Name = "Username")]
        public String Username { get; set; }

        [Required(ErrorMessage = "You must enter the password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public String Password { get; set; }

        [Display(Name = "Remember on this computer")]
        public bool Remember { get; set; }
    }

    public class ChangePasswordModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage="Please enter the old password.")]
        [DataType(DataType.Password)]
        [Display(Name="Current Password")]
        public String CurrentPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public String NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("NewPassword", ErrorMessage="The new password and confirmation password are not match.")]
        public String ConfirmPassword { get; set; } 
    }

}