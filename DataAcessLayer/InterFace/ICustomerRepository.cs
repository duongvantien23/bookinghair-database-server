using DataModel;
using System.Collections.Generic;

namespace DataAcessLayer.InterFace
{
    public partial interface ICustomerRepository
    {
        bool Create(CustomerModel customer);
        bool Update(CustomerModel customer);
        bool Delete(int customerId);
        List<CustomerModel> GetAll();
        CustomerModel GetById(int customerId);
    }
}
