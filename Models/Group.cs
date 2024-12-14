using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace BUMS
{
    public class Group
    {
        [Display(Name = "Group ID")]
        public int GroupID { get; set; }

        [Required]
        [Display(Name = "Group Name")]
        [StringLength(50)]
        public string? GroupName { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CreatedBy { get; set; }

        [Display(Name = "Access")]
        public Access? Access {get;set;}
        [Display(Name = "Access ID")]
        public int AccessID { get; set; }

        [ValidateNever]
        public virtual ICollection<UserGroup>? UserGroups { get; set; }
    }
}