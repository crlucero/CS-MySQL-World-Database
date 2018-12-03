using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using World.Models;

namespace World.Controllers
{
    public class CityController : Controller
    {
        [HttpGet("/cities")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet("/cities/show")]
        public ActionResult Show()
        {
            // City newCity = new City(cityName);
            List<City> allCities = City.GetAll();
            return View(allCities);
        }

        [HttpPost("/cities/show")]
        public ActionResult SearchedCity(string cityName)
        {
            List<City> allCities = City.SearchedCity(cityName);
            return View("Show", allCities);
        }

    }
}
