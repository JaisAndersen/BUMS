using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BUMS
{
        public class Access
    {
        [Display(Name = "AccessID")]
        public int AccessID { get; set; }
        [Required]
        [Display(Name = "AccessName")]
        [MaxLength(50), MinLength(0)]
        public string AccessName { get; set; }
        [Required]
        [Display(Name = "System name")]
        [MaxLength(50), MinLength(0)]
        public string SystemName { get; set; }
        //public ICollection<UserGroup> UserGroups { get; set; }
        //public ICollection<Group> Groups { get; set; }
    }
}
