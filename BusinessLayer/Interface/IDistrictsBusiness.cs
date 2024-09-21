using DataModel;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
    public interface IDistrictsBusiness
    {
        bool CreateDistrict(DistrictsModel district);
        bool UpdateDistrict(DistrictsModel district);
        bool DeleteDistrict(int districtId);
        List<DistrictsModel> GetAllDistricts();
        DistrictsModel GetDistrictById(int districtId);
    }
}
