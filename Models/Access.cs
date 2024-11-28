using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BUMS.Models
{
        public class Access
    {        
        [Required]
        public int AccessID { get; set; }
        public string AccessName { get; set; }
        public string SystemName { get; set; }
        public ICollection<UserGroup> UserGroups { get; set; }
    }
}
