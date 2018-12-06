using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Transactions;
using System.Text;
using RunningShoeQuestionaire.Models;

namespace RunningShoeQuestionaire.DAL
{
    public interface IQuestionaireDAL
    {
        void AddQuestionaire(Questionaire questionaire);
        Questionaire GetLatestQuestionaire();
    }
}
