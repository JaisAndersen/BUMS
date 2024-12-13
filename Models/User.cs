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

        public int CreatedBy { get; set; }

        [ValidateNever]
        public virtual ICollection<UserGroup> UserGroup { get; set; }
    }
}
