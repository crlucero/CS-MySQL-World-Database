using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using World;

namespace World.Models
{
    public class Country
    {
        private string _countryName;
        // private int _id;
        private string _countryCode;
        private int _population;

        public Country (string countryName)
        {
            _countryName = countryName;
        }

        public Country (string countryName, string countryCode)
        {
            _countryName = countryName;
            _countryCode = countryCode;
        }

        public Country (string countryName, int population)
        {
            _countryName = countryName;
            _population = population;
        }

        public string GetCountryName()
        {
            return _countryName;
        }

        public string GetId()
        {
            return _countryCode;
        }
        public int GetCountryPop()
        {
            return _population;
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
            string countryCode = rdr.GetString(0);
            string countryName = rdr.GetString(1);
            Country newCountryName = new Country(countryName, countryCode);
            allCountries.Add(newCountryName);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allCountries;
        }


    public static List<Country> SearchedCountry(string searchCountry)
        {
        List<Country> newCountry = new List<Country> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM country WHERE Name LIKE '%"+ searchCountry +"%';";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
            // int cityId = rdr.GetInt32(0);
            string countryCode = rdr.GetString(0);
            string countryName = rdr.GetString(1);
            Country newCountryName = new Country(countryName, countryCode);
            newCountry.Add(newCountryName);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return newCountry;
        }

        public static List<Country> FindCountry(string countryCode)
        {
            List<Country> newCountryList = new List<Country> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM country WHERE Code = '"+ countryCode +"';";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                // int cityId = rdr.GetInt32(0);
                string countryName = rdr.GetString(1);
                int pop = rdr.GetInt32(6);
                Country clickedCountry = new Country(countryName, pop);
                newCountryList.Add(clickedCountry);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newCountryList;
        }
        
        

    }
}
