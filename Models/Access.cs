using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BUMS.Models
{
        public class Access
    {
        //public Access() { }
        [Required]
        public string AccessID { get; set; }

        public string AccessName { get; set; }

        public string SystemName { get; set; }

        //public virtual ICollection<UserGroup> AccessUserGroups { get; set; }
    }
}
