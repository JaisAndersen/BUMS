using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BUMS.Models
{
        public class Access
    {
        [Display(Name = "Access id")]
        public int AccessID { get; set; }
        [Required]
        [Display(Name = "Access name")]
        [MaxLength(50), MinLength(0)]
        public string AccessName { get; set; }
        [Required]
        [Display(Name = "System name")]
        [MaxLength(50), MinLength(0)]
        public string SystemName { get; set; }
        //public ICollection<UserGroup> UserGroups { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
