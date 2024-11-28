using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BUMS.Models{
    public class Group{
        [Display(Name = "Group id")]
        public int GroupID { get; set; }
        [Display(Name = "Group name")]
        public string GroupName { get; set; }
        [Display(Name = "Created at")]
        public DateTime CreatedAt { get; set; }
        [Display(Name = "Created by")]
        public User CreatedBy { get; set; }

        public virtual ICollection<UserGroup> GroupUserGroups {get;set;}
    }
}
