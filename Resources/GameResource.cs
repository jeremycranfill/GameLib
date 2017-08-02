using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Vega.Models
{



    public class GameResource
    {
        public int Id { get; set; }
        public int Family { get; set; }
        public int FamilyID { get; set; }
        
        public bool Recommended { get; set; }
        
        public GameInfoResource Info { get; set; }
           


        public Collection<int> Mechanics { get; set; }

        public GameResource()
        {
            Mechanics = new Collection<int>();

        }
      

    }
}
