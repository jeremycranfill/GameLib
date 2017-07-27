using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vega.Models
{
    public class Category
    {


        public int Id { get; set; }
        [Required]
        [StringLength(255)]


        public string Name { get; set; }

        public Family Family {get; set;}
        public int FamilyId { get; set; }

    }

}
