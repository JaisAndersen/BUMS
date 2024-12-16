using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace BUMS
{
    public class User : IdentityUser
    {
        //public int UserID { get; set; }
        [Display(Name ="User ID")]
        public int UserNavigationID { get; set; }

        [Required]
        [Display(Name = "User Name")]
        [StringLength(50)]
        public override string UserName { get; set; }

        [Required]
        [Display(Name = "User Email")]
        [DataType(DataType.EmailAddress)]
        public override string Email { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string? UpdatedBy { get; set; }



        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [ValidateNever]
        public virtual ICollection<UserGroup> UserGroup { get; set; }
    }
}