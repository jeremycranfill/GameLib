using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vega.Resources;

namespace Vega.Models
{
    public class Family
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        public ICollection<Category> Categories { get; set; }

        public Family()
        {
            Categories = new Collection<Category>();

        }
    }
}
