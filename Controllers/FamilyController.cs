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
    public class FamilyController : Controller
    {
        // GET: /<controller>/
        private readonly VegaDbContext context;
        private readonly IMapper mapper;

        public FamilyController(VegaDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;

        }
            [HttpGet("/api/family")]
            public async Task<IEnumerable<FamilyResource>> GetFamiliies()
            {

            var fams = await context.Families.Include(m => m.Categories).ToListAsync();
            return mapper.Map<List<Family>, List<FamilyResource>> (fams);

            }



          
    }
}
