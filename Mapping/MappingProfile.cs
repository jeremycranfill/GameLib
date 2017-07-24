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
            CreateMap<Family, FamilyResource>();
            CreateMap<Category, CategoryResource>();
        }



    }
}
