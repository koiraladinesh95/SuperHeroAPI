using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private static List<SuperHero> cities = new List<SuperHero>
            {
                new SuperHero
                {

                    Name = "Rick",
                   Age = 22,
                   City = "Austin"
                },


                  new SuperHero
                  {

                    Name = "Abishek",
                    Age = 40,
                   City = "Dallas"
                  },

                    new SuperHero
                    {

                        Name = "Dinesh",
                        Age =60,
                        City = "Austin"
                    }
        };
        private static List<Tech> Developer = new List<Tech>
        {
            new Tech
            {
                Name = "Dinesh",
                Technology = "C#"
            },
            new Tech
            {
                Name = "Abishek",
                Technology = "Java"
            },
            new Tech
            {
                Name = "Rex",
                Technology = "Devops"

            },
            new Tech
            {
                Name = "Rick",
                Technology = "QA"

            }
        };


            
        [HttpGet("{name}")]
       
        public async Task <ActionResult > Get(string name)
        {

        var nameresult = cities.Join(Developer,
            city=>city.Name, dev=>dev.Name,(city,dev)=>
            new
            {
                WorkedName = city.Name,
                WorkedLocation = city.City,
                WorkedDescription = dev.Technology
            });
            if (nameresult == null)   
                return BadRequest("City not Found");

            return Ok(nameresult.Where( h => h.WorkedName == name));

        }
    }
}



