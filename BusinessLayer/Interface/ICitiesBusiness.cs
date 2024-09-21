using DataModel;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
    public partial interface ICitiesBusiness
    {
        bool CreateCity(CitiesModel city);
        bool UpdateCity(CitiesModel city);
        bool DeleteCity(int cityId);
        List<CitiesModel> GetAllCities();
        CitiesModel GetCityById(int cityId);
    }
}
