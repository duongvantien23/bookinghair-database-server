using DataModel;
using System.Collections.Generic;

namespace DataAcessLayer.InterFace
{
    public partial interface ICitiesRepository
    {
        bool Create(CitiesModel city);
        bool Update(CitiesModel city);
        bool Delete(int cityId);
        List<CitiesModel> GetAll();
        CitiesModel GetById(int cityId);
    }
}
