using DataModel;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
    public interface IServiceDetailBusiness
    {
        bool CreateServiceDetail(ServiceDetailModel serviceDetail);
        bool UpdateServiceDetail(ServiceDetailModel serviceDetail);
        bool DeleteServiceDetail(int serviceDetailId);
        List<ServiceDetailModel> GetAllServiceDetails();
        ServiceDetailModel GetServiceDetailById(int serviceDetailId);
    }
}
