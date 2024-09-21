using DataModel;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
    public partial interface ICustomerBusiness
    {
        bool CreateCustomer(CustomerModel customer);
        bool UpdateCustomer(CustomerModel customer);
        bool DeleteCustomer(int customerId);
        List<CustomerModel> GetAllCustomers();
        CustomerModel GetCustomerById(int customerId);
    }
}
