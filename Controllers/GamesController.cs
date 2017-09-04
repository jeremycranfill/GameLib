using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vega.Models;
using AutoMapper;
using Vega.Data;
using Microsoft.EntityFrameworkCore;
using Vega.Resources;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vega.Controllers
{
    [Route("/api/games")]
    public class GamesController : Controller
    {
        private IMapper mapper;
        private VegaDbContext context;
        private IGameRepository repository;
        private IUnitOfWork unitOfWork;

        public GamesController(IMapper mapper, VegaDbContext dbcontext, IGameRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.context = dbcontext;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
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
            repository.Add(game);



            await unitOfWork.Complete();
            game = await repository.GetGame(game.Id);
           



            var result = mapper.Map<Game, GameResource>(game);

            return Ok(result);
        }


        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateGame(int id, [FromBody]SaveGameResource gameResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }




            var game = await repository.GetGame(id);
            if (game == null)
                return NotFound();

            mapper.Map<SaveGameResource, Game>(gameResource, game);
            game.LastUpdate = DateTime.Now;

            await unitOfWork.Complete();

            game = await repository.GetGame(game.Id);
            var result = mapper.Map<Game, GameResource>(game);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameAsync(int id)

        {
            var game = await repository.GetGame(id, includeRelated: false);
            if (game == null)
                return NotFound();
            repository.Remove(game);
            await unitOfWork.Complete();

            return Ok(id);



        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGame(int id)
        {
            var game = await repository.GetGame(id);
            if (game == null)
                return NotFound();

            var gameResource = mapper.Map<Game, GameResource>(game);
            return Ok(gameResource);

        }












}
}
