using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vega.Models;

namespace Vega.Data
{
    public class GameRepository : IGameRepository
    {
        private VegaDbContext context;

        public GameRepository(VegaDbContext context)
        {
            this.context = context;
        }


        public async Task<Game> GetGame(int id, bool includeRelated = true)
        {

            if (!includeRelated)
            {
                return await context.Games.FindAsync(id);
            }

            return await context.Games
                 .Include(g => g.Mechanics)
                 .ThenInclude(gm => gm.Mechanic)
                 .Include(c => c.Catergory)
                 .ThenInclude(f => f.Family)
                 .SingleOrDefaultAsync(g => g.Id == id);

        }

        public void Add(Game game)
        {
            context.Games.Add(game);
            

            
        }

        public void Remove(Game game) {
            context.Remove(game);
          
        }

        
    }








}
