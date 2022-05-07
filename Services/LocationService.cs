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
        IEnumerable<LocationModel> GetStates();
        IEnumerable<LocationModel> GetCities(int stateId);
        IEnumerable<LocationModel> GetWards(int cityId);
        IEnumerable<LocationModel> CitiesHaveBranches(int stateId);
        IEnumerable<LocationModel> StatesHaveBranches();
    }

    public class LocationService : ILocationService
    {
        private DataContext _context;

        public LocationService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<LocationModel> GetStates()
        {
            try{
                return _context.VNStates.Select(x => new LocationModel { Id = x.Id, Name = x.Name }).OrderBy(x => x.Name)
                                      .ToList();
            }catch(Exception e){
                var a = e.Message;
                throw;
            }
        }

        public IEnumerable<LocationModel> GetCities(int stateId)
        {
            try{
                return _context.VNCities.Where(x => stateId != 0 ? x.StateId == stateId : true)
                                      .Select(x => new LocationModel { Id = x.Id, Name = x.Name }).OrderBy(x => x.Name)
                                      .ToList();
            }catch(Exception e){
                var a = e.Message;
                throw;
            }
        }

        public IEnumerable<LocationModel> GetWards(int cityId)
        {
            try{
                return _context.VNWards.Where(x => cityId != 0 ? x.CityId == cityId : true)
                                     .Select(x => new LocationModel { Id = x.Id, Name = x.Name }).OrderBy(x => x.Name)
                                     .ToList();
            }catch(Exception e){
                var a = e.Message;
                throw;
            }
        }


        public IEnumerable<LocationModel> CitiesHaveBranches(int stateId)
        {
            try{
                var cities = _context.VNCities.Where(x => x.StateId == stateId)
                                      .Join(_context.Branches, x => x.Id, y => y.CityId, 
                                            (x, y) => new LocationModel {
                                                                            Id = y.CityId,
                                                                            Name = x.Name
                                                                        })
                                      .Distinct()
                                      .ToList();
                return cities;
            }catch(Exception e){
                var a = e.Message;
                throw;
            }
        }

        public IEnumerable<LocationModel> StatesHaveBranches()
        {
            try{
                var states = _context.VNStates.Join(_context.Branches, x => x.Id, y => y.ProvinceId, 
                                            (x, y) => new LocationModel {
                                                                            Id = y.ProvinceId,
                                                                            Name = x.Name
                                                                        })
                                        .Distinct()
                                      .ToList();
                return states;
            }catch(Exception e){
                var a = e.Message;
                throw;
            }
        }

    }
}