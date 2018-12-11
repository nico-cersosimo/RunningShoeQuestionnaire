using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunningShoeQuestionaire.Models
{
    public class Brand
    {
        public string Name { get; set; }
        public int AvgCost { get; set; }

        public static List<Brand> TrailAndTerrainFilter(Questionaire questionaire, List<Brand> brands)
        {
            if (questionaire.Terrain != null && (questionaire.Terrain.Equals("Trail") || questionaire.Terrain.Equals("All-Terrain")))
            {
                brands = brands.Where(x => x.Name != "Nike" && x.Name != "Adidas" && x.Name != "New Balance").ToList();
            }
            return brands;
        }
    }
}
