using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vega.Models;
using AutoMapper;
using Vega.Data;

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

            var game = mapper.Map<GameResource, Game>(gameResource);
            game.LastUpdate = DateTime.Now;
            context.Games.Add(game);
             await context.SaveChangesAsync();
           var result= mapper.Map<Game, GameResource>(game);

            return Ok(result);
        }
    }
}
