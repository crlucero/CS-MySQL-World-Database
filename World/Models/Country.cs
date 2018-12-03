using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using World;

namespace World.Models
{
    public class Country
    {
        private string _countryName;

        public Country (string countryName)
        {
            _countryName = countryName;
        }

        public string GetCountryName()
        {
            return _countryName;
        }


        public static List<Country> GetAll()
        {
        List<Country> allCountries = new List<Country> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM country;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
            // int countryId = rdr.GetInt32(0);
            string countryName = rdr.GetString(1);
            Country newCountryName = new Country(countryName);
            allCountries.Add(newCountryName);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allCountries;
        }

    }
}
