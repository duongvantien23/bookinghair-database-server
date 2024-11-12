using DataAccessLayer;
using DataAcessLayer.InterFace;
using DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAcessLayer
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly IDatabaseHelper _dbHelper;

        public ServiceRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        // Thêm mới dịch vụ
        public bool Create(ServiceModel service)
        {
            string msgError = "";
            try
            {
                // Gọi stored procedure để tạo dịch vụ
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_service",
                    "@NameService", service.NameService,
                    "@Description", service.Description,
                    "@ImageServices", service.ImageServices,
                    "@Price", service.Price,
                    "@CategoryId", service.CategoryId,
                    "@Duration", service.Duration);

                // Kiểm tra lỗi từ stored procedure
                if (!string.IsNullOrEmpty(msgError))
                {
                    Console.WriteLine("Stored Procedure Error: " + msgError);
                    throw new Exception(msgError);
                }

                // Kiểm tra kết quả trả về từ stored procedure
                if (result == null || string.IsNullOrEmpty(result.ToString()))
                {
                    Console.WriteLine("Stored Procedure returned no result.");
                    throw new Exception("Stored Procedure returned no result.");
                }

                Console.WriteLine("Result: " + result.ToString());
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating service: " + ex.Message);
                throw new Exception("Error creating service: " + ex.Message);
            }
        }
        // Cập nhật dịch vụ
        public bool Update(ServiceModel service)
        {
            string msgError = "";
            try
            {
                // Gọi stored procedure để cập nhật dịch vụ
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_service",
                    "@ServiceId", service.ServiceId,
                    "@NameService", service.NameService,
                    "@Description", service.Description,
                    "@ImageService", service.ImageServices,
                    "@Price", service.Price,
                    "@Duration", service.Duration,
                    "@CategoryId", service.CategoryId); 

                // Kiểm tra lỗi sau khi cập nhật dịch vụ
                if (!string.IsNullOrEmpty(msgError) || (result != null && !string.IsNullOrEmpty(result.ToString())))
                {
                    throw new Exception(msgError + Convert.ToString(result));
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating service: " + ex.Message);
            }
        }

        // Xóa dịch vụ
        public bool Delete(int serviceId)
        {
            string msgError = "";
            try
            {
                // Xóa dịch vụ
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_delete_service",
                    "@ServiceId", serviceId);

                if (!string.IsNullOrEmpty(msgError) || (result != null && !string.IsNullOrEmpty(result.ToString())))
                {
                    throw new Exception(msgError + Convert.ToString(result));
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting service: " + ex.Message);
            }
        }

        // Lấy danh sách tất cả các dịch vụ
        public List<ServiceModel> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_all_services");

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<ServiceModel>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting services list: " + ex.Message);
            }
        }

        // Lấy thông tin dịch vụ theo ID
        public ServiceModel GetById(int serviceId)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_service_by_id", "@ServiceId", serviceId);

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                var service = dt.ConvertTo<ServiceModel>().FirstOrDefault();

                return service;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting service by ID: " + ex.Message);
            }
        }
        // Lấy danh sách chi tiết dịch vụ theo ID dịch vụ
        public List<ServiceDetailModel> GetServiceDetailsByServiceId(int serviceId)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_service_details_by_service_id", "@ServiceId", serviceId);

                // Kiểm tra lỗi từ stored procedure
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<ServiceDetailModel>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting service details by ServiceId: " + ex.Message);
            }
        }
    }
}
