using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using World.Models;

namespace World.Controllers
{
    public class CountryController : Controller
    {
        [HttpGet("/country")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet("/country/show")]
        public ActionResult Show()
        {
            // City newCity = new City(cityName);
            List<Country> allCountries = Country.GetAll();
            return View(allCountries);
        }
    }
}