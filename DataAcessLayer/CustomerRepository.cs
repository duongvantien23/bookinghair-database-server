using DataAccessLayer;
using DataAcessLayer.InterFace;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAcessLayer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDatabaseHelper _dbHelper;

        public CustomerRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        // Thêm mới khách hàng
        public bool Create(CustomerModel customer)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_customer",
                    "@NameCustomer", customer.NameCustomer,
                    "@Phone", customer.Phone,
                    "@Email", customer.Email,
                    "@CityId", customer.CityId,
                    "@DistrictId", customer.DistrictId);

                if (!string.IsNullOrEmpty(msgError) || (result != null && !string.IsNullOrEmpty(result.ToString())))
                {
                    throw new Exception(msgError + Convert.ToString(result));
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating customer: " + ex.Message);
            }
        }

        // Cập nhật thông tin khách hàng
        public bool Update(CustomerModel customer)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_customer",
                    "@CustomerId", customer.CustomerId,
                    "@NameCustomer", customer.NameCustomer,
                    "@Phone", customer.Phone,
                    "@Email", customer.Email,
                    "@CityId", customer.CityId,
                    "@DistrictId", customer.DistrictId);

                if (!string.IsNullOrEmpty(msgError) || (result != null && !string.IsNullOrEmpty(result.ToString())))
                {
                    throw new Exception(msgError + Convert.ToString(result));
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating customer: " + ex.Message);
            }
        }

        // Xóa khách hàng
        public bool Delete(int customerId)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_delete_customer",
                    "@CustomerId", customerId);

                if (!string.IsNullOrEmpty(msgError) || (result != null && !string.IsNullOrEmpty(result.ToString())))
                {
                    throw new Exception(msgError + Convert.ToString(result));
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting customer: " + ex.Message);
            }
        }

        // Lấy danh sách tất cả khách hàng
        public List<CustomerModel> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_all_customers");

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<CustomerModel>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting customer list: " + ex.Message);
            }
        }

        // Lấy thông tin khách hàng theo ID
        public CustomerModel GetById(int customerId)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_customer_by_id", "@CustomerId", customerId);

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<CustomerModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting customer by ID: " + ex.Message);
            }
        }
    }
}
