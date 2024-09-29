using BusinessLayer.Interface;
using DataAcessLayer.InterFace;
using DataModel;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class ServiceDetailBusiness : IServiceDetailBusiness
    {
        private readonly IServiceDetailRepository _serviceDetailRepository;

        public ServiceDetailBusiness(IServiceDetailRepository serviceDetailRepository)
        {
            _serviceDetailRepository = serviceDetailRepository;
        }
        public bool CreateServiceDetail(ServiceDetailModel serviceDetail)
        {
            return _serviceDetailRepository.Create(serviceDetail);
        }
        public bool UpdateServiceDetail(ServiceDetailModel serviceDetail)
        {
            return _serviceDetailRepository.Update(serviceDetail);
        }
        public bool DeleteServiceDetail(int serviceDetailId)
        {
            return _serviceDetailRepository.Delete(serviceDetailId);
        }
        public List<ServiceDetailModel> GetAllServiceDetails()
        {
            return _serviceDetailRepository.GetAll();
        }

        public ServiceDetailModel GetServiceDetailById(int serviceDetailId)
        {
            return _serviceDetailRepository.GetById(serviceDetailId);
        }
    }
}
