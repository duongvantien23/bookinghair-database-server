using DataModel;
using System.Collections.Generic;

namespace DataAcessLayer.InterFace
{
    public partial interface ISalonRepository
    {
        bool Create(SalonModel salon);
        bool Update(SalonModel salon);
        bool Delete(int salonId);
        List<SalonModel> GetAll();
        SalonModel GetById(int salonId);
    }
}
