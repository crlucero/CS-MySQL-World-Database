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


        [HttpPost("/country/show")]
        public ActionResult SearchedCountry(string countryName)
        {
            List<Country> allCountries = Country.SearchedCountry(countryName);
            return View("Show", allCountries);
        }

        [HttpGet("/country/show/{countryCode}")]
        public ActionResult Details(string countryCode)
        {
            List<Country> country = Country.FindCountry(countryCode);
            List<City> cityList = City.FindCity(countryCode);
            Dictionary<string, object> model = new Dictionary<string, object>();
            model.Add("cities", cityList);
            model.Add("country", country);
            return View(model);
        }
    }
}