using DataModel;
using System.Collections.Generic;

namespace DataAcessLayer.InterFace
{
    public partial interface IDistrictsRepository
    {
        bool Create(DistrictsModel district);
        bool Update(DistrictsModel district);
        bool Delete(int districtId);
        List<DistrictsModel> GetAll();
        DistrictsModel GetById(int districtId);
    }
}
