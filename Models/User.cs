using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace BUMS
{
    public class User : IdentityUser
    {
        public int UserID { get; set; }

        [Required]
        [Display(Name = "User Name")]
        [StringLength(50)]
        public string? UserName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        public int CreatedBy { get; set; }

        [ValidateNever]
        public virtual ICollection<UserGroup>? UserGroup { get; set; }
    }
}
