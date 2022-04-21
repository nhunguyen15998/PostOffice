using post_office.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using post_office.Entities;
using Microsoft.EntityFrameworkCore;

namespace post_office.Services
{
    public interface ILocationService
    {
        IEnumerable<LocationModel> GetCountries(List<int> ids);
        IEnumerable<LocationModel> GetStates(int countryId);
        IEnumerable<LocationModel> GetCities(int stateId);
        IEnumerable<LocationModel> GetWards(int cityId);
        IEnumerable<LocationModel> CitiesHaveBranches(int stateId);
        IEnumerable<LocationModel> StatesHaveBranches(int countryId);
    }

    public class LocationService : ILocationService
    {
        private DataContext _context;

        public LocationService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<LocationModel> GetCountries(List<int> ids)
        {
            try{
                return _context.Countries.Where(x => ids.Contains(x.id))
                                        .Select(x => new LocationModel { Id = x.id, Name = x.name })
                                        .ToList();
            }catch(Exception e){
                var a = e.Message;
                throw;
            }
        }

        public IEnumerable<LocationModel> GetStates(int countryId)
        {
            try{
                return _context.States.Where(x => x.country_id == countryId)
                                      .Select(x => new LocationModel { Id = x.id, Name = x.name })
                                      .ToList();
            }catch(Exception e){
                var a = e.Message;
                throw;
            }
        }

        public IEnumerable<LocationModel> GetCities(int stateId)
        {
            try{
                return _context.Cities.Where(x => x.state_id == stateId)
                                      .Select(x => new LocationModel { Id = x.id, Name = x.name })
                                      .ToList();
            }catch(Exception e){
                var a = e.Message;
                throw;
            }
        }

        public IEnumerable<LocationModel> GetWards(int cityId)
        {
            try{
                return _context.Wards.Where(x => x.city_id == cityId)
                                     .Select(x => new LocationModel { Id = x.id, Name = x.name })
                                     .ToList();
            }catch(Exception e){
                var a = e.Message;
                throw;
            }
        }


        public IEnumerable<LocationModel> CitiesHaveBranches(int stateId)
        {
            try{
                var cities = _context.Cities.Where(x => x.state_id == stateId)
                                      .Join(_context.Branches, x => x.id, y => y.CityId, 
                                            (x, y) => new LocationModel {
                                                                            Id = y.CityId,
                                                                            Name = x.name
                                                                        })
                                      .ToList();
                return cities;
            }catch(Exception e){
                var a = e.Message;
                throw;
            }
        }

        public IEnumerable<LocationModel> StatesHaveBranches(int countryId)
        {
            try{
                var states = _context.States.Where(x => x.country_id == countryId)
                                      .Join(_context.Branches, x => x.id, y => y.ProvinceId, 
                                            (x, y) => new LocationModel {
                                                                            Id = y.ProvinceId,
                                                                            Name = x.name
                                                                        })
                                      .ToList();
                return states;
            }catch(Exception e){
                var a = e.Message;
                throw;
            }
        }

    }
}