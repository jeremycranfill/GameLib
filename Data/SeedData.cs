using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vega.Models;

namespace Vega.Data
{
    public class SeedData
    {
        public static void Initialize(VegaDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Families.Any())
            {
                return; //Data already seeded

            }

            var Families = new Family[]
                {
                    new Family{Name="Strategy"},
                    new Family{Name="Abstract"},
                    new Family{Name="War"},
                    new Family{Name="Thematic"}
                };
            foreach (Family f in Families)
            {
                context.Families.Add(f);

            }
            context.SaveChanges();

            var Categories = new Category[]
                {
                    new Category{Name="Dice",FamilyId=1},
                    new Category{Name="Drafting",FamilyId=1},
                    new Category{Name="Tiles",FamilyId=1},
                    new Category{Name="Deck Building",FamilyId=2},
                    new Category{Name="Farming",FamilyId=2 },
                    new Category{Name="Negotiaion",FamilyId=3},
                   new Category{Name="Stock",FamilyId=4},
                    new Category{Name="Combat",FamilyId=4},

                };

            foreach (Category c in Categories)
            { context.Categories.Add(c); }



            context.SaveChanges();


            var Mechanics = new Mechanic[]

        {
            new Mechanic{Name="Dice Drafting" },
             new Mechanic{Name="Dice Drafting" },
              new Mechanic{Name="Dice Drafting" },
               new Mechanic{Name="Variable Player Powers" },


        };

            foreach (Mechanic m in Mechanics)
            { context.Mechanics.Add(m); }
            context.SaveChanges();



    }
    }

}