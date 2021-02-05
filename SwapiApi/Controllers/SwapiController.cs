using Microsoft.AspNetCore.Mvc;
using SwapiApi.Models;
using SwapiApi.Services;
using System.Threading.Tasks;

namespace SwapiApi.Controllers
{
    public class SwapiController : Controller
    {
        private readonly IPlanetClient _planetClient;

        public SwapiController(IPlanetClient planetClient)
        {
            _planetClient = planetClient;           
        }

        public async Task<IActionResult> ChangePage(string url)
        {
            var UrlStrippedToPageInfo = url.Substring(url.Length - 15);
            var model = new PlanetResponse();
            var response = await _planetClient.GetPlanetInfo(UrlStrippedToPageInfo);
            model.results = response.results;
            model.previous = response.previous;
            model.next = response.next;
            return View("GetAllPlanets",model);
        }
        public async Task<IActionResult> GetAllPlanets()
        {

            var model = new PlanetResponse();
            var response = await _planetClient.GetPlanetInfo();
            model.results = response.results;
            model.next = response.next;
            model.previous = response.previous;
            return View(model);
        }

    }
}
