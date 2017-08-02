using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Vega.Models;
using Vega.Resources;


namespace Vega.Mapping
{
    public class MappingProfile: Profile
    {

        public MappingProfile()
        {
            //domain to api
            CreateMap<Family, FamilyResource>();
            CreateMap<Category, CategoryResource>();
            CreateMap<Game, GameResource>()
                .ForMember(gr => gr.Info, opt => opt.MapFrom(g => new GameInfoResource { Year = g.Year, Designer = g.Designer, Publisher = g.Publisher }))
                .ForMember(gr => gr.Mechanics, opt => opt.MapFrom(g => g.Mechanics.Select(gm => gm.MechanicId)));


            //api to domain
            CreateMap<GameResource, Game>()
                .ForMember(v => v.Designer, opt => opt.MapFrom(gr => gr.Info.Designer))
                .ForMember(v => v.Publisher, opt => opt.MapFrom(gr => gr.Info.Publisher))
                .ForMember(v => v.Year, opt => opt.MapFrom(gr => gr.Info.Year))
                .ForMember(v => v.Mechanics, opt => opt.MapFrom(gr => gr.Mechanics.Select(ID => new GameMechanic { MechanicId = ID })));

        }



    }
}
