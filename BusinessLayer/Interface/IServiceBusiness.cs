using DataModel;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
    public partial interface IServiceBusiness
    {
        bool CreateService(ServiceModel service);
        bool UpdateService(ServiceModel service);
        bool DeleteService(int serviceId);
        List<ServiceModel> GetAllServices();
        ServiceModel GetServiceById(int serviceId);
        List<ServiceDetailModel> GetServiceDetailsByServiceId(int serviceId);

    }
}
