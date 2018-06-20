using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace Lab11MyFirstMVCApp.Models
{
    public class TimePerson
    {
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }

        public TimePerson()
        {

        }
        /// <summary>
        /// Method to grab our list of people and then filter out
        /// the selected years
        /// </summary>
        /// <param name="beginYear">Start Year</param>
        /// <param name="endYear">End Year</param>
        /// <returns>List of filtered People</returns>
        public List<TimePerson> GetPeople(int beginYear, int endYear)
        {
            //Instantiate a list of type TimePerson
            List<TimePerson> people = new List<TimePerson>();
            //Here is the setup for finding the file.
            //First we set a string path to the application's current directory
            string path = Environment.CurrentDirectory;
            //Now we are locating our csv file
            string filePath = Path.GetFullPath(Path.Combine(path, @"wwwroot\personOfTheYear.csv"));
            //Storing the file in an array
            string[] file = File.ReadAllLines(filePath);

            for(int i = 1; i < file.Length; i++)
            {
                //Set i to 1 to avoid the title line
                //and now split properties by comma to add our people
                string[] properties = file[i].Split(',');
                people.Add(new TimePerson
                {
                    Year = Convert.ToInt32(properties[0]),
                    Honor = properties[1],
                    Name = properties[2],
                    Country = properties[3],
                    //These two have a chance to be an empty string so to handle that
                    //we check if the string isn't empty. If that is true, convert the incoming
                    //string to int else just set it to 0 to avoid a FormatException
                    BirthYear = properties[4] != "" ? Convert.ToInt32(properties[4]) : 0,
                    DeathYear = properties[5] != "" ? Convert.ToInt32(properties[5]) : 0,
                    Title = properties[6],
                    Category = properties[7],
                    Context = properties[8]
                });
            }
            //Now we are using a Lambda expression to only select the people within the
            //given years and return the list
            List<TimePerson> peopleList = people.Where(person => (person.Year >= beginYear) && (person.Year <= endYear)).ToList();
            return peopleList;
        }
    }
}
