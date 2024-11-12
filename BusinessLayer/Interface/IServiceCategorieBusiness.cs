using System.Collections.Generic;
using DataModel;

namespace BusinessLayer.Interface
{
    public partial interface IServiceCategorieBusiness
    {
        bool CreateCategory(ServiceCategorieModel category);
        bool UpdateCategory(ServiceCategorieModel category);
        bool DeleteCategory(int categoryId);
        List<ServiceCategorieModel> GetAllCategories();
        ServiceCategorieModel GetCategoryById(int categoryId);
        List<ServiceModel> GetServicesByCategoryId(int categoryId);
    }
}
