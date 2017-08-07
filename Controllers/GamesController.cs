using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vega.Models;
using AutoMapper;
using Vega.Data;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vega.Controllers
{
    [Route("/api/games")]
    public class GamesController : Controller
    {
        private IMapper mapper;
        private VegaDbContext context;

        public GamesController(IMapper mapper, VegaDbContext dbcontext)
        {
            this.mapper = mapper;
            this.context = dbcontext;
        }


        [HttpPost]

        public async Task<IActionResult> CreateGame([FromBody]GameResource gameResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }




            var game = mapper.Map<GameResource, Game>(gameResource);
            game.LastUpdate = DateTime.Now;
            context.Games.Add(game);
            await context.SaveChangesAsync();
            var result = mapper.Map<Game, GameResource>(game);

            return Ok(result);
        }


        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateGame(int id, [FromBody]GameResource gameResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }




            var game = await context.Games.Include(g => g.Mechanics).SingleOrDefaultAsync(v => v.Id == id);
            if (game == null)
                return NotFound();

            mapper.Map<GameResource, Game>(gameResource, game);
            game.LastUpdate = DateTime.Now;

            await context.SaveChangesAsync();
            var result = mapper.Map<Game, GameResource>(game);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameAsync(int id)

        {
            var game = await context.Games.FindAsync(id);
            if (game == null)
                return NotFound();
            context.Remove(game);
            await context.SaveChangesAsync();

            return Ok(id);



        }

        [HttpPost("{id}")]
        public async Task<IActionResult> GetGame(int id)
        {
            var game = await context.Games.Include(g => g.Mechanics).SingleOrDefaultAsync(g => g.Id== id);
            if (game == null)
                return NotFound();

            var gameResource = mapper.Map<Game, GameResource>(game);
            return Ok(gameResource);

        }












}
}
