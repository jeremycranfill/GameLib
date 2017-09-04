using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Vega.Models;

namespace Vega.Resources
{
    public class GameResource
    {
        public int Id { get; set; }
        public KeyValuePairResource Family { get; set; }
       public KeyValuePairResource Category { get; set; }
        public GameInfoResource Info { get; set; }
       
        public int Year { get; set; }

        public DateTime LastUpdate { get; set; }


        public ICollection<KeyValuePairResource> Mechanics { get; set; }


        public GameResource()
        {
            Mechanics = new Collection<KeyValuePairResource>();

        }

    }
}
