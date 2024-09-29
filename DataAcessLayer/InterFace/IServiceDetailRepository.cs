using DataModel;
using System.Collections.Generic;

namespace DataAcessLayer.InterFace
{
    public partial interface IServiceDetailRepository
    {
        bool Create(ServiceDetailModel serviceDetail);
        bool Update(ServiceDetailModel serviceDetail);
        bool Delete(int serviceDetailId);
        List<ServiceDetailModel> GetAll();
        ServiceDetailModel GetById(int serviceDetailId);
    }
}
