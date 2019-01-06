using EKlubas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Persistence.DatabaseSeed
{
    public static class CitySeed
    {
        public static List<City> GetCityListSeed()
        {
            var cities = new List<City>
            {
                new City() { Id = 1, Name = "Vilnius" },
                new City() { Id = 2, Name = "Kaunas" },
                new City() { Id = 3, Name = "Klaipėda" },
                new City() { Id = 4, Name = "Šiauliai" },
                new City() { Id = 5, Name = "Panevėžys" },
                new City() { Id = 6, Name = "Palanga" },
                new City() { Id = 7, Name = "Marijampolė" }
            };

            return cities;
        }
    }
}
