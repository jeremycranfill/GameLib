using System.ComponentModel.DataAnnotations;

namespace Vega.Models
{
    public class GameInfoResource
    {
        [Required]
        [StringLength(255)]
        public string Designer { get; set; }
        [Required]
        [StringLength(255)]
        public string Publisher { get; set; }
        [Required]

        public int Year { get; set; }



    }
}
