using DataModel;
using System.Collections.Generic;

namespace DataAcessLayer.InterFace
{
    public partial interface IServiceRepository
    {
        bool Create(ServiceModel service);
        bool Update(ServiceModel service);
        bool Delete(int serviceId);
        List<ServiceModel> GetAll();
        ServiceModel GetById(int serviceId);
        List<ServiceDetailModel> GetServiceDetailsByServiceId(int serviceId);
    }
}
