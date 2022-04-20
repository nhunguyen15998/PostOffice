using post_office.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using post_office.Entities;

namespace post_office.Services
{
    public interface ILocationService
    {
        IEnumerable<Country> GetCountries();
        IEnumerable<State> GetStates();
        IEnumerable<City> GetCities();
        IEnumerable<Ward> GetWards();
        IEnumerable<LocationModel> GetState(int countryId);
        IEnumerable<LocationModel> GetCity(int stateId);
        IEnumerable<LocationModel> GetWard(int cityId);
    }

    public class LocationService : ILocationService
    {
        private DataContext _context;

        public LocationService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Country> GetCountries()
        {
            try{
                return _context.Countries.ToList();
            }catch(Exception e){
                var a = e.Message;
                throw;
            }
        }

        public IEnumerable<State> GetStates()
        {
            try{
                return _context.States.ToList();
            }catch(Exception e){
                var a = e.Message;
                throw;
            }
        }

        public IEnumerable<City> GetCities()
        {
            try{
                return _context.Cities.ToList();
            }catch(Exception e){
                var a = e.Message;
                throw;
            }
        }

        public IEnumerable<Ward> GetWards()
        {
            try{
                return _context.Wards.ToList();
            }catch(Exception e){
                var a = e.Message;
                throw;
            }
        }

        public IEnumerable<LocationModel> GetState(int countryId)
        {
            try{
                return _context.States.Where(x => x.country_id == countryId)
                                        .Select(x => new LocationModel{
                                            Id = x.id,
                                            Name = x.name
                                        })
                                        .ToList();
            }catch(Exception e){
                var a = e.Message;
                throw;
            }
        }

        //return list of cities by country
        public IEnumerable<LocationModel> GetCity(int stateId)
        {
            try{
                return _context.Cities.Where(x => x.state_id == stateId)
                                      .Select(x => new LocationModel{
                                            Id = x.id,
                                            Name = x.name
                                        })
                                        .ToList();
            }catch(Exception e){
                var a = e.Message;
                throw;
            }
        }

        //return list of cities by country
        public IEnumerable<LocationModel> GetWard(int cityId)
        {
            try{
                return _context.Wards.Where(x => x.city_id == cityId)
                                      .Select(x => new LocationModel{
                                            Id = x.id,
                                            Name = x.name
                                        })
                                        .ToList(); 
            }catch(Exception e){
                var a = e.Message;
                throw;
            }
        }
    }
}