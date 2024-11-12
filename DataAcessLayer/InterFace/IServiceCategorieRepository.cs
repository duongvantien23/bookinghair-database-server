using System.Collections.Generic;
using DataModel;

namespace DataAcessLayer.InterFace
{
    public partial interface IServiceCategorieRepository
    {
        bool Create(ServiceCategorieModel category);
        bool Update(ServiceCategorieModel category);
        bool Delete(int categoryId);
        List<ServiceCategorieModel> GetAll();
        ServiceCategorieModel GetById(int categoryId);
        List<ServiceModel> GetServicesByCategoryId(int categoryId);
    }
}
