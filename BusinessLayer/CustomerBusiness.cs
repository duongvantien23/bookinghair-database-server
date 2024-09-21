using BusinessLayer.Interface;
using DataAcessLayer.InterFace;
using DataModel;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class CustomerBusiness : ICustomerBusiness
    {
        private readonly ICustomerRepository _res;

        public CustomerBusiness(ICustomerRepository res)
        {
            _res = res;
        }

        public bool CreateCustomer(CustomerModel customer)
        {
            return _res.Create(customer);
        }

        public bool UpdateCustomer(CustomerModel customer)
        {
            return _res.Update(customer);
        }

        public bool DeleteCustomer(int customerId)
        {
            return _res.Delete(customerId);
        }

        public List<CustomerModel> GetAllCustomers()
        {
            return _res.GetAll();
        }

        public CustomerModel GetCustomerById(int customerId)
        {
            return _res.GetById(customerId);
        }
    }
}
