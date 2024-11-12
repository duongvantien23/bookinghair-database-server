using BusinessLayer.Interface;
using DataAcessLayer.InterFace;
using DataModel;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class SalonBusiness : ISalonBusiness
    {
        private readonly ISalonRepository _salonRepository;

        public SalonBusiness(ISalonRepository salonRepository)
        {
            _salonRepository = salonRepository;
        }

        public bool CreateSalon(SalonModel salon)
        {
            return _salonRepository.Create(salon);
        }

        public bool UpdateSalon(SalonModel salon)
        {
            return _salonRepository.Update(salon);
        }

        public bool DeleteSalon(int salonId)
        {
            return _salonRepository.Delete(salonId);
        }

        public List<SalonModel> GetAllSalons()
        {
            return _salonRepository.GetAll();
        }

        public SalonModel GetSalonById(int salonId)
        {
            return _salonRepository.GetById(salonId);
        }
        public List<SalonModel> GetSalonsByDistrictId(int districtId)
        {
            return _salonRepository.GetByDistrictId(districtId);
        }
    }
}
