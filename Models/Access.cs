using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BUMS.Models{
        public class Access{
        [Display(Name = "Access id")]
        public int AccessID { get; set; }
        [Required]
        [Display(Name = "Access name")]
        public string AccessName { get; set; }
        [Required]
        [Display(Name = "System name")]
        public string SystemName { get; set; }

        public virtual ICollection<UserGroup> AccessUserGroups {get;set;}
    }
}
