using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RunningShoeQuestionaire.Models;

namespace RunningShoeQuestionaire.DAL
{
    public interface IBrandDAL
    {
        List<Brand> GetAllBrands();
    }
}
