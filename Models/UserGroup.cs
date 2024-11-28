﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BUMS.Models
{
    public class UserGroup
    {
        public int UserGroupID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int GroupID { get; set; }
        public Group Group { get; set; }
        public int AccessID { get; set; }
        public Access Access { get; set; }
        
       

    }
}
