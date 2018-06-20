using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab11MyFirstMVCApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab11MyFirstMVCApp.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Action that is called when the user first visits site
        /// </summary>
        /// <returns>Index.cshtml view</returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Action that waits for a post from the form on the Index.cshtml file
        /// </summary>
        /// <param name="beginYear">User inputted beginning year</param>
        /// <param name="endYear">User inputted ending year</param>
        /// <returns>Redirects to the Results action</returns>
        [HttpPost]
        public IActionResult Index(int beginYear, int endYear)
        {
            return RedirectToAction("Results", new { minYear = beginYear, maxYear = endYear });
        }
        /// <summary>
        /// Action that takes input from the Index Action Redirect and instantiates a TimePerson
        /// object based on the received input
        /// </summary>
        /// <param name="minYear">Starting year</param>
        /// <param name="maxYear">Ending year</param>
        /// <returns>selectedPeople object that has all of our filtered data</returns>
        public IActionResult Results(int minYear, int maxYear)
        {
            TimePerson peoples = new TimePerson();
            List<TimePerson> selectedPeople = new List<TimePerson> (peoples.GetPeople(minYear, maxYear));
            return View(selectedPeople);
        }
    }
}
