using BusinessLayer.Interface;
using DataAcessLayer.InterFace;
using DataModel;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class CitiesBusiness : ICitiesBusiness
    {
        private readonly ICitiesRepository _citiesRepository;

        public CitiesBusiness(ICitiesRepository citiesRepository)
        {
            _citiesRepository = citiesRepository;
        }

        public bool CreateCity(CitiesModel city)
        {
            return _citiesRepository.Create(city);
        }

        public bool UpdateCity(CitiesModel city)
        {
            return _citiesRepository.Update(city);
        }

        public bool DeleteCity(int cityId)
        {
            return _citiesRepository.Delete(cityId);
        }

        public List<CitiesModel> GetAllCities()
        {
            return _citiesRepository.GetAll();
        }

        public CitiesModel GetCityById(int cityId)
        {
            return _citiesRepository.GetById(cityId);
        }
    }
}
