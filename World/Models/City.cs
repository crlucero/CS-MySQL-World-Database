using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using World;

namespace World.Models
{
    public class City
    {
        private string _cityName;

        public City (string cityName)
        {
            _cityName = cityName;
        }

        public string GetCityName()
        {
            return _cityName;
        }

        public static List<City> GetAll()
        {
        List<City> allCities = new List<City> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM city;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
            // int cityId = rdr.GetInt32(0);
            string cityName = rdr.GetString(1);
            City newCityName = new City(cityName);
            allCities.Add(newCityName);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allCities;
        }

          public static List<City> SearchedCity(string searchCity)
        {
        List<City> newCity = new List<City> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM city WHERE name LIKE '"+ searchCity +"';";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
            // int cityId = rdr.GetInt32(0);
            string cityName = rdr.GetString(1);
            City newCityName = new City(cityName);
            newCity.Add(newCityName);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return newCity;
        }
    }

}
