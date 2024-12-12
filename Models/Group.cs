using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BUMS
{
    public class Group
    {
        [Display(Name = "Group id")]
        public int GroupID { get; set; }

        [Required]
        [Display(Name = "Group name")]
        [StringLength(50)]
        public string GroupName { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CreatedBy { get; set; }

        [Display(Name = "Access")]
        public Access? Access {get;set;}
        [Display(Name = "AccessID")]
        public int AccessID { get; set; }

        [ValidateNever]
        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }
}
