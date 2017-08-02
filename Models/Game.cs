using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vega.Models
{
    public class Game
    {
        public int Id { get; set; }
        public int Family { get; set; }
        public int FamilyID { get; set; }
        
        public bool Recommended { get; set; }
        [Required]
        [StringLength(255)]
        public string Designer { get; set; }
        [Required]
        [StringLength(255)]
        public string Publisher { get; set; }
        [Required]
        
        public int Year { get; set; }

        public DateTime LastUpdate { get; set; }


        public ICollection<GameMechanic> Mechanics { get; set; }

        public Game()
        {
            Mechanics = new Collection<GameMechanic>();
        }

    }
}
