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

        //location
        [HttpGet]
        public IEnumerable<LocationModel> GetStates()
        {
            return _locationService.GetStates();
        }

        [HttpGet]
        public IEnumerable<LocationModel> GetCitiesByState([FromQuery] int provinceId)
        {
            return _locationService.GetCities(provinceId);
        }

        [HttpGet]
        public IEnumerable<LocationModel> GetWardsByCity([FromQuery] int districtId)
        {
            return _locationService.GetWards(districtId);
        }

        //branch
        [HttpGet]
        public IEnumerable<LocationModel> CitiesHaveBranches([FromQuery] int stateId)
        {
            return _locationService.CitiesHaveBranches(stateId);
        }
        [HttpGet]
        public IEnumerable<LocationModel> StatesHaveBranches()
        {
            return _locationService.StatesHaveBranches();
        }
        [HttpGet]
        public IEnumerable<ReadBranchModel> GetBranchesByCities([FromQuery] int cityId, int branchId)
        {
            return _branchService.GetBranchesByConditions(cityId, branchId);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
