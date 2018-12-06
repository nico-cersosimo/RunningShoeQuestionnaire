using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RunningShoeQuestionaire.Models;
using RunningShoeQuestionaire.DAL;

namespace RunningShoeQuestionaire.Controllers
{
    public class HomeController : Controller
    {
        IBrandDAL brandDAL = new BrandDAL(@"Data Source=.\SQLEXPRESS;Initial Catalog=RunningShoe;Integrated Security=True");
        IQuestionaireDAL questionaireDAL = new QuestionaireDAL(@"Data Source=.\SQLEXPRESS;Initial Catalog=RunningShoe;Integrated Security=True");
        public HomeController(IBrandDAL brandDAL, IQuestionaireDAL questionaireDAL)
        {
            this.brandDAL = brandDAL;
            this.questionaireDAL = questionaireDAL;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Questionaire()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Submit(Questionaire questionaire)
        {
            //questionaire = 
            return RedirectToAction("Results");
        }

        [HttpGet]
        public IActionResult Results()
        {
            var brands = brandDAL.GetAllBrands();
            return View(brands);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
