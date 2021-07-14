using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heros.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class HerosController : ControllerBase
    {
        private static List<Hero> Summaries = new List<Hero>()
        {
      new Hero{ id = 11, name = "Dr Nice" },
      new Hero{ id =  12, name =  "Narco" },
      new Hero{ id =  13, name =  "Bombasto" },
      new Hero{ id =  14, name =  "Celeritas" },
      new Hero{ id =  15, name =  "Magneta" },
      new Hero{ id =  16, name =  "RubberMan" },
      new Hero{ id =  17, name =  "Dynama" },
      new Hero{ id =  18, name =  "Dr IQ" },
      new Hero{ id =  19, name =  "Magma" },
      new Hero{ id =  20, name =  "Tornado" }
        };

        private readonly ILogger<HerosController> _logger;

        public HerosController(ILogger<HerosController> logger)
        {
            _logger = logger;
            Summaries = Load();
        }
        [NonAction]
        private List<Hero> Load()
        {
            string json = System.IO.File.ReadAllText("heros.json");
            List<Hero> items = JsonConvert.DeserializeObject<List<Hero>>(json);
            return items;

        }
        [NonAction]
        private void Save(List<Hero> heroes)
        {
            string json = JsonConvert.SerializeObject(heroes);
            System.IO.File.WriteAllText(@"heros.json", json);
        }

        [NonAction]
        private int GenId(){
            return Summaries.Count > 0 ? Summaries.Max(hero => hero.id) + 1 : 11;
        }

    [HttpGet]
        public IEnumerable<Hero> Get()
        {
            return Summaries
            .ToArray();
        }

        [HttpGet]
        [Route("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(Summaries.Where(p=> p.id == id).FirstOrDefault());
        }

        [HttpGet]
        [Route("search/{name}")]
        public IEnumerable<Hero> Get(string name)
        {
            return Summaries.Where(p => p.name == name)
            .ToArray();
        }

        [HttpPost]
        public JsonResult Post([Microsoft.AspNetCore.Mvc.FromBody] Hero hero)
        {
            hero.id = GenId();
            Summaries.Add(hero);
            Save(Summaries);
            return new JsonResult(hero);
        }

        [HttpPut]
        public JsonResult Put([Microsoft.AspNetCore.Mvc.FromBody] Hero hero)
        {
            var obj = Summaries.Find(h=> h.id == hero.id);
            if (obj != null) obj.name = hero.name;

            Save(Summaries);
            return new JsonResult(0);
        }
        [HttpDelete]
        public JsonResult Delete([Microsoft.AspNetCore.Mvc.FromBody] Hero hero)
        {
            Summaries.Remove(hero);
            Save(Summaries);
            return new JsonResult(0);
        }
    }
}
