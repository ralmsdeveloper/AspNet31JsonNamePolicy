using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNet31JsonNamePolicy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private static readonly string[] Peoples = new[]
        {
            "Rafael", "Thysbe", "Heloysa", "Eduarda"
        };

        private readonly ILogger<PeopleController> _logger;

        public PeopleController(ILogger<PeopleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Person
            {
                BirtdayDate = DateTime.Now.AddDays(index),
                Email = "ralms@ralms.net",
                FullName = Peoples[rng.Next(Peoples.Length)]
            })
            .ToArray();
        }
    }
}
