using BusinessLayer.Interface;
using DataAcessLayer.InterFace;
using DataModel;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class ServiceBusiness : IServiceBusiness
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceBusiness(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public bool CreateService(ServiceModel service)
        {
            return _serviceRepository.Create(service);
        }

        public bool UpdateService(ServiceModel service)
        {
            return _serviceRepository.Update(service);
        }

        public bool DeleteService(int serviceId)
        {
            return _serviceRepository.Delete(serviceId);
        }

        public List<ServiceModel> GetAllServices()
        {
            return _serviceRepository.GetAll();
        }

        public ServiceModel GetServiceById(int serviceId)
        {
            return _serviceRepository.GetById(serviceId);
        }
        public List<ServiceDetailModel> GetServiceDetailsByServiceId(int serviceId)
        {
            return _serviceRepository.GetServiceDetailsByServiceId(serviceId);
        }
    }
}
