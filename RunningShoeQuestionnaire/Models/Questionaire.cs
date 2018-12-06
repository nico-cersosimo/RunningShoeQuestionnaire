using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RunningShoeQuestionaire.Models
{
    public class Questionaire
    {
        public string Terrain { get; set; }
        public string FootShape { get; set; }
        public string Design { get; set; }
        public string Color { get; set; }
        public string Cost { get; set; }
        public string Popularity { get; set; }
        public string BottomShape { get; set; }
        public string Name { get; set; }

        public static List<SelectListItem> terrains = new List<SelectListItem>()
        {
            new SelectListItem {Value="Road/Track", Text="Road/Track"},
            new SelectListItem {Value="Treadmill/Gym", Text="Treadmill/Gym" },
            new SelectListItem {Value="Trail", Text="Trail" },
            new SelectListItem {Value="All-Terrain", Text="All-Terrain" }
        };

        public static List<SelectListItem> footShapes = new List<SelectListItem>()
        {
            new SelectListItem {Value="Wide", Text="Wide"},
            new SelectListItem {Value="Narrow", Text="Narrow" },
            new SelectListItem {Value="Neutral", Text="Neutral" }
        };

        public static List<SelectListItem> designs = new List<SelectListItem>()
        {
            new SelectListItem {Value="Naturesque", Text="Naturesque"},
            new SelectListItem {Value="Abstract", Text="Abstract" },
            new SelectListItem {Value="Plain & Simple", Text="Plain & Simple" }
        };

        public static List<SelectListItem> colors = new List<SelectListItem>()
        {
            new SelectListItem {Value="Many Colors", Text="Many Colors"},
            new SelectListItem {Value="A Few Colors", Text="A Few Colors" },
            new SelectListItem {Value="One Color", Text="One Color" }
        };

        public static List<SelectListItem> costs = new List<SelectListItem>()
        {
            new SelectListItem {Value="Under $100", Text="Under $100"},
            new SelectListItem {Value="Between $100 & $120", Text="Between $100 & $120" },
            new SelectListItem {Value="Over $120", Text="Over $120" }
        };

        public static List<SelectListItem> popularity = new List<SelectListItem>()
        {
            new SelectListItem {Value="Popular", Text="Popular"},
            new SelectListItem {Value="Underground", Text="Underground" },
            new SelectListItem {Value="Somewhat Known", Text="Somewhat Known" }
        };

        public static List<SelectListItem> bottomShape = new List<SelectListItem>()
        {
            new SelectListItem {Value="Curved", Text="Curved"},
            new SelectListItem {Value="Flat", Text="Flat" },
            new SelectListItem {Value="Neutral", Text="Neutral" }
        };
    }
}
