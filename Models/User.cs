using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BUMS.Models{
    public class User{
        public int UserID {get;set;}

        [Required]
        [Column("User_Name")]
        public string UserName {get;set;}

        [Column("Created_At")]
        public DateTime CreatedAt {get;set;}

        [Column("Created_By")]
        public User CreatedBy {get;set;}

        //public virtual ICollection<UserGroup> UserUserGroups { get; set; }
    }
}
