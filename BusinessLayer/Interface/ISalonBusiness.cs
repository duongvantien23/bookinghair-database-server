using DataModel;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
    public interface ISalonBusiness
    {
        bool CreateSalon(SalonModel salon);
        bool UpdateSalon(SalonModel salon);
        bool DeleteSalon(int salonId);
        List<SalonModel> GetAllSalons();
        SalonModel GetSalonById(int salonId);
    }
}
