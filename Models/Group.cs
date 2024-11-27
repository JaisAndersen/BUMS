using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BUMS.Models
{
    [Table("Group")]
    public class Group
    {
        [Key]
        [Column("Group_Id")]
        public int GroupID { get; set; }
        [Column("Group_Name")]
        public string GroupName { get; set; }
        [Column("Created_At")]
        public DateTime CreatedAt { get; set; }
        [Column("Created_By")]
        public User CreatedBy { get; set; }

        public virtual ICollection<UserGroup> GroupUserGroups {get;set;}
    }
}
