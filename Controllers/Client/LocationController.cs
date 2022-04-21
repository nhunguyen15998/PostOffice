using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using post_office.Models;
using post_office.Services;

namespace post_office.Controllers.Client
{
    public class LocationController : Controller
    {   
        private readonly ILogger<LocationController> _logger;
        private ILocationService _locationService;
        private IBranchService _branchService;

        public LocationController(ILogger<LocationController> logger, ILocationService locationService, IBranchService branchService)
        {
            _logger = logger;
            _locationService = locationService;
            _branchService = branchService;
        }

        [HttpGet]
        public IEnumerable<LocationModel> GetCountries()
        {
            return _locationService.GetCountries(DefaultCountries.countryIds);
        }

        [HttpGet]
        public IEnumerable<LocationModel> GetStatesByCountry([FromQuery] int countryId)
        {
            return _locationService.GetStates(countryId);
        }

        [HttpGet]
        public IEnumerable<LocationModel> GetCitiesByState([FromQuery] string stateId)
        {
            return _locationService.GetCities(int.Parse(stateId));
        }

        [HttpGet]
        public IEnumerable<LocationModel> GetWardsByCity([FromQuery] int cityId)
        {
            return _locationService.GetWards(cityId);
        }

        //branch
        [HttpGet]
        public IEnumerable<LocationModel> CitiesHaveBranches([FromQuery] int stateId)
        {
            return _locationService.CitiesHaveBranches(stateId);
        }
        [HttpGet]
        public IEnumerable<LocationModel> StatesHaveBranches([FromQuery] int countryId)
        {
            return _locationService.StatesHaveBranches(countryId);
        }
        [HttpGet]
        public IEnumerable<ReadBranchModel> GetBranchesByCities([FromQuery] int cityId)
        {
            return _branchService.GetBranchesByConditions(cityId);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
