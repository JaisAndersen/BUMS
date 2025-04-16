using System.ComponentModel.DataAnnotations;

namespace BUMS {
    public class Access {
        [Display(Name = "Access ID")]
        public int AccessID { get; set; }

        [Required]
        [Display(Name = "Access Name")]
        [MaxLength(50), MinLength(0)]
        public string? AccessName { get; set; }

        [Required]
        [Display(Name = "System Name")]
        [MaxLength(50), MinLength(0)]
        public string? SystemName { get; set; }
    }
}
