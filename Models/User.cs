using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BUMS.Models
{
    public class User
    {
        public int UserID { get; set; }

        [Required]
        [Display(Name = "User name")]
        [MaxLength(100), MinLength(0)]
        public string UserName { get; set; }

        [Display(Name = "Created at")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Created by")]
        public int CreatedBy { get; set; }

        [ValidateNever]
        public virtual ICollection<UserGroup> UserGroup { get; set; }
    }
}
