using System.Collections.Generic;
using BusinessLayer.Interface;
using DataAcessLayer.InterFace;
using DataModel;

namespace BusinessLayer
{
    public class ServiceCategorieBusiness : IServiceCategorieBusiness
    {
        private readonly IServiceCategorieRepository _serviceCategorieRepository;

        public ServiceCategorieBusiness(IServiceCategorieRepository serviceCategorieRepository)
        {
            _serviceCategorieRepository = serviceCategorieRepository;
        }

        public bool CreateCategory(ServiceCategorieModel category)
        {
            return _serviceCategorieRepository.Create(category);
        }

        public bool UpdateCategory(ServiceCategorieModel category)
        {
            return _serviceCategorieRepository.Update(category);
        }

        public bool DeleteCategory(int categoryId)
        {
            return _serviceCategorieRepository.Delete(categoryId);
        }

        public List<ServiceCategorieModel> GetAllCategories()
        {
            return _serviceCategorieRepository.GetAll();
        }

        public ServiceCategorieModel GetCategoryById(int categoryId)
        {
            return _serviceCategorieRepository.GetById(categoryId);
        }
        public List<ServiceModel> GetServicesByCategoryId(int categoryId)
        {
            return _serviceCategorieRepository.GetServicesByCategoryId(categoryId);
        }
    }
}
