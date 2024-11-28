using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BUMS.Models{
    public class UserGroup{
        [Display(Name = "User group id")]
        public int UserGroupID {get;set;}
        [Display(Name = "User id")]
        public int UserID {get;set;}
        [Display(Name = "Group id")]
        public int GroupID{get;set;}
        [Display(Name = "Access id")]
        public int AccessID{get;set;}

        //public virtual UserGroup UserUserGroupNavigation {get;set;}

        //public virtual Access AccessUserGroupNavigation {get;set;}

        //public virtual Group GroupUserGroupNavigation {get;set;}
    }
}
