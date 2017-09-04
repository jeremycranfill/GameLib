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
            CreateMap<Mechanic, KeyValuePairResource>();
            CreateMap<Family, FamilyResource>();
            CreateMap<Family, KeyValuePairResource>();
            CreateMap<Category, KeyValuePairResource>();
            CreateMap<Game, SaveGameResource>()
                .ForMember(gr => gr.Info, opt => opt.MapFrom(g => new GameInfoResource { Year = g.Year, Title = g.Title, Publisher = g.Publisher }))
                .ForMember(gr => gr.Mechanics, opt => opt.MapFrom(g => g.Mechanics.Select(gm => gm.MechanicId)));

            CreateMap<Game, GameResource>()
                    .ForMember(Gr => Gr.Family, opt => opt.MapFrom(g => g.Catergory.Family  ))
                     .ForMember(Gr => Gr.Info, opt => opt.MapFrom(h => new GameInfoResource { Year = h.Year, Title = h.Title, Publisher = h.Publisher }))
                     .ForMember(Gr => Gr.Mechanics, opt => opt.MapFrom(h => h.Mechanics.Select(gm => new KeyValuePairResource { Id = gm.Mechanic.Id, Name = gm.Mechanic.Name })));



            //api to domain
            CreateMap<SaveGameResource, Game>()
                .ForMember(v => v.Id, opt => opt.Ignore())
                .ForMember(v => v.Title, opt => opt.MapFrom(gr => gr.Info.Title))
                .ForMember(v => v.Publisher, opt => opt.MapFrom(gr => gr.Info.Publisher))
                .ForMember(v => v.Year, opt => opt.MapFrom(gr => gr.Info.Year))
                //.ForMember(v => v.Mechanics, opt => opt.MapFrom(gr => gr.Mechanics.Select(ID => new GameMechanic { MechanicId = ID })));
                .ForMember(v => v.Mechanics, opt => opt.Ignore())
                .AfterMap((gr, g) => {
                   
                     var removedMechanics = g.Mechanics.Where(m => !gr.Mechanics.Contains(m.MechanicId));
                                                                       
                    foreach (var m in removedMechanics)
                        g.Mechanics.Remove(m);


                    



                    //add new mechanics

                    var addedMechanics = gr.Mechanics.Where(id => !g.Mechanics.Any(m => m.MechanicId == id)).Select(id => new GameMechanic{MechanicId=id});
                    foreach (var m in addedMechanics)
                        g.Mechanics.Add(m);
                });         
                
                
        }



    }
}
