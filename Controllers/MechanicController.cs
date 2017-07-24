using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vega.Models;
using Vega.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Vega.Resources;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vega.Controllers
{
    public class MechanicController
        : Controller
    {
        // GET: /<controller>/
        private readonly VegaDbContext context;
       

        public MechanicController(VegaDbContext context)
        {
            this.context = context;
            

        }
            [HttpGet("/api/mechanic")]
            public async Task<IEnumerable<Mechanic>> GetMechanics()
            {

            var mechs = await context.Mechanics.ToListAsync();
            return mechs;

            }



          
    }
}
