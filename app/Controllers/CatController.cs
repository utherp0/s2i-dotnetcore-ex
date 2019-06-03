using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MeowWorld.Controllers
{
    public class CatController : Controller
    {
        [HttpGet("cat/{cat}")]
        public string Cat(string cat)
        {
            switch (cat)
            {
                case "winnie":
                    return "Meow! Hiss! Meow!";
                case "molly":
                    return "Silent Purr. Silent Kill.";
                case "dexter":
                    return "Meow. Barf. Meow.";
                case "kali":
                    return "Meow. Meow. Meow. Hiss. Bite. Meow.";
                case "jessie":
                    return "Pounce. Purr. Pounce. Purr.";
                case "murphy":
                    return "Nom nom nom nom nom nom nom nom.";
            }

            return "No Such cat!";
        }

        [HttpGet("cat/all")]
        public IActionResult All()
        {
            return View();
        }

        [HttpGet("cat/version")]
        public string Version()
        {
            return "Version 1.0";
        }

    }
}