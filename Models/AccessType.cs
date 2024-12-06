using System.ComponentModel.DataAnnotations;

namespace BUMS{
    public enum AccessType{
        [Display(Name = "Admin")]
        Admin,
        [Display(Name = "User")]
        User,
        [Display(Name = "UserAdmin")]
        UserAdmin
    }
}
