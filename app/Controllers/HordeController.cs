using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MeowWorld.Controllers
{
    public class HordeController : Controller
    {
        private static Dictionary<string, string> _Cats = new Dictionary<string, string>();

        [HttpPost("horde/{cat}")]
        public string Post(string cat, [FromBody]string sound)
        {
            _Cats[cat] = sound;

            return String.Format("{0} added to the horde!", cat);
        }

        [HttpGet("horde/{cat}")]
        public string Get(string cat)
        {
            if (!_Cats.ContainsKey(cat))
            {
                return "Cat not found.";
            }

            return _Cats[cat];
        }

        [HttpPatch("horde/{cat}")]
        public string Patch(string cat, [FromBody]string sound)
        {
            if (!_Cats.ContainsKey(cat))
            {
                return "Cat not found.";
            }

            _Cats[cat] = sound;

            return "Cat updated.";
        }

        [HttpDelete("horde/{cat}")]
        public string Delete(string cat)
        {
            if (!_Cats.ContainsKey(cat))
            {
                return "Cat not found.";
            }

            _Cats.Remove(cat);

            return "Cat deleted.";
        }

        [HttpGet("horde/all")]
        public IActionResult All()
        {
            var cats = new Models.Cats();

            cats.Names = _Cats.Keys.ToArray();

            return View(cats);
        }

        [HttpGet("horde/cat/{cat}")]
        public IActionResult Cat(string cat)
        {
            Models.Cat model = null;

            if (_Cats.ContainsKey(cat))
            {
                model = new Models.Cat
                {
                    Name = cat,
                    Sound = _Cats[cat],
                };
            }

            return View(model);
        }

        [HttpGet("horde/add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("horde/add")]
        public IActionResult Add(string name, string sound)
        {
            _Cats[name] = sound;

            return Redirect("/horde/all");
        }
    }
}