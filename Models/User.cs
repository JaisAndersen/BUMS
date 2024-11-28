using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BUMS.Models{
    public class User{
        public int UserID {get;set;}

        [Required]
        [Column("User_Name")]
        public string UserName {get;set;}
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public ICollection<UserGroup> UserGroups { get; set; }
    }
}
