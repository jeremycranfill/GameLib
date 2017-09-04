using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vega.Models
{



    public class SaveGameResource
    {
        public int Id { get; set; }
        public int Family { get; set; }
        public int FamilyID { get; set; }
        
        public bool Recommended { get; set; }
        [Required]
        public GameInfoResource Info { get; set; }
           


        public Collection<int> Mechanics { get; set; }

        public SaveGameResource()
        {
            Mechanics = new Collection<int>();

        }
      

    }
}
