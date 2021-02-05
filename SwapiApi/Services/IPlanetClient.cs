using SwapiApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwapiApi.Services
{
    public interface IPlanetClient
    {
        public Task<PlanetResponse> GetPlanetInfo();
        public Task<PlanetResponse> GetPlanetInfo(string urlStrippedToPageInfo);
    }
}
