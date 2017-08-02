using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vega.Models
{
    public class GameMechanic
    {
        public int GameId { get; set; }
        public int MechanicId { get; set; }

        public Game Game { get; set; }
        public Mechanic Mechanic { get; set; }

    }
}
