using System.ComponentModel.DataAnnotations;

namespace IC02_kmg_SportsPro.Models
{
    public class Country
    {
        [Required]
        [Key]
        public string CountryID { get; set; }

        [Required]  
        public string Name { get; set; }

    }
}
