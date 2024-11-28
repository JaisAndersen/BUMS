using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BUMS.Models{
    public class User{
        [Display(Name = "User id")]
        public int UserID {get;set;}
        [Display(Name = "User name")]
        public string UserName {get;set;}
        [Display(Name = "Created at")]
        public DateTime CreatedAt {get;set;}
        [Display(Name = "Created by")]
        public User CreatedBy {get;set;}

        public virtual ICollection<UserGroup> UserUserGroups {get;set;}
    }
}
