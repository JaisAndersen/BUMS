using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BUMS.Models
{
        public class Access
    {
        //public Access() { }
        [Required]
        [Key]
        [Column("Access_id")]
        public string AccessID { get; set; }

        [Column("Access_Name")]
        public string AccessName { get; set; }

        [Column("System_Name")]
        public string SystemName { get; set; }

        //public virtual ICollection<UserGroup> AccessUserGroups { get; set; }
    }
}
