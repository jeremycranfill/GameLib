using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Vega.Models;
using Vega.Resources;

namespace Vega.Resources
{
    public class FamilyResource
    {

        public int Id { get; set; }
       
        public string Name { get; set; }


        public ICollection<CategoryResource> Categories { get; set; }

        public FamilyResource()
        {
            Categories = new Collection<CategoryResource>();

        }
    }
}
