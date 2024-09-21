using DataModel;
using System.Collections.Generic;

namespace DataAcessLayer.InterFace
{
    public interface IServiceRepository
    {
        bool Create(ServiceModel service);
        bool Update(ServiceModel service);
        bool Delete(int serviceId);
        List<ServiceModel> GetAll();
        ServiceModel GetById(int serviceId);
    }
}
