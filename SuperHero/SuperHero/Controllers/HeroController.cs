using SuperHero.Domain.Abstract;
using SuperHero.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SuperHero.Controllers
{
    public class HeroController : Controller
    {
        private IHeroRepository repository;

        public HeroController(IHeroRepository _repository) => this.repository = _repository;


        public ViewResult Index()
        {
            return View();
        }

        [Route("character/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var heroe = await this.repository.HeroById(id);
                return View(heroe);
            }
            catch (Exception exce)
            {
                ViewBag.ErrorMessage = exce.Message;
                return View("~/Views/Shared/_Error.cshtml");
            }
        }

        [Route("")]
        public async Task<ActionResult> HeroByStringSearch(string searchString = "")
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchString)) { Session["searchString"] = ""; return View("Index"); }
                var heroes = await this.repository.HeroByStringSearch(searchString);
                Session["searchString"] = searchString;
                return View(heroes);
            }
            catch (Exception exce)
            {
                ViewBag.ErrorMessage = exce.Message;
                return View("~/Views/Shared/_Error.cshtml");
            }
        }
    }
}