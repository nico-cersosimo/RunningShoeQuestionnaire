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
        public List<Brand> Brands { get; set; }
    }
}
