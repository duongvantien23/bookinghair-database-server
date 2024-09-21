using DataModel;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
    public interface IServiceBusiness
    {
        bool CreateService(ServiceModel service);
        bool UpdateService(ServiceModel service);
        bool DeleteService(int serviceId);
        List<ServiceModel> GetAllServices();
        ServiceModel GetServiceById(int serviceId);
    }
}
