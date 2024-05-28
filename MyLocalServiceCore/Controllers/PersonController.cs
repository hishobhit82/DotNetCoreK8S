using Microsoft.AspNetCore.Mvc;
using MyLocalEntities;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace MyLocalServiceCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly string personsFileName = "Persons.csv";
        private readonly string personsFilePath;

        public PersonController()
        {
            personsFilePath = personsFileName;
        }

        [HttpGet("GetPersons/{value}")]
        public ServiceResult<Person> GetData(int value)
        {
            var persons = new List<Person>();

            if (!System.IO.File.Exists(personsFilePath))
            {
                throw new Exception("Data not found.");
            }

            using (var sw = new StreamReader(personsFilePath))
            {
                while (!sw.EndOfStream)
                {
                    if (value == 0) break;

                    var line = sw.ReadLine()?.Split(',');
                    if(line == null) continue;
                    var personObj = new Person()
                    {
                        Name = line[0],
                        Age = Convert.ToInt32(line[1].Substring(3, line[1].Length - 3)),
                        City = line[2],
                        Qualities = Person.GetQualities(line[3])
                    };

                    persons.Add(personObj);

                    value--;
                }
            };

            var result = new ServiceResult<Person>(persons.ToArray());
            return result;
        }

        [HttpGet("GetAllPersonNames")]
        public ServiceResult<string> GetAllPersonNames()
        {
            var personNames = new List<string>();

            if (!System.IO.File.Exists(personsFilePath))
            {
                throw new Exception("Data not found.");
            }

            using (var sw = new StreamReader(personsFilePath))
            {
                while (!sw.EndOfStream)
                {
                    var line = sw.ReadLine()?.Split(',');
                    if (line == null) continue;
                    personNames.Add(line[0]);
                }
            };

            var result = new ServiceResult<string>(personNames.ToArray());
            return result;
        }

        [HttpGet("Ping")]
        public ServiceResult<string> Ping()
        {
            return new ServiceResult<string>(
                new[] { new StringBuilder("Service running successfully.." + Environment.NewLine + $"UserName= {Environment.UserName}").ToString() });
        }
    }
}
