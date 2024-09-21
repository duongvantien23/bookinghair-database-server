using BusinessLayer.Interface;
using DataAcessLayer.InterFace;
using DataModel;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class DistrictsBusiness : IDistrictsBusiness
    {
        private readonly IDistrictsRepository _districtsRepository;

        public DistrictsBusiness(IDistrictsRepository districtsRepository)
        {
            _districtsRepository = districtsRepository;
        }

        public bool CreateDistrict(DistrictsModel district)
        {
            return _districtsRepository.Create(district);
        }

        public bool UpdateDistrict(DistrictsModel district)
        {
            return _districtsRepository.Update(district);
        }

        public bool DeleteDistrict(int districtId)
        {
            return _districtsRepository.Delete(districtId);
        }

        public List<DistrictsModel> GetAllDistricts()
        {
            return _districtsRepository.GetAll();
        }

        public DistrictsModel GetDistrictById(int districtId)
        {
            return _districtsRepository.GetById(districtId);
        }
    }
}
