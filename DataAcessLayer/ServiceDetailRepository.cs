using DataAccessLayer;
using DataAcessLayer.InterFace;
using DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAcessLayer
{
    public class ServiceDetailRepository : IServiceDetailRepository
    {
        private readonly IDatabaseHelper _dbHelper;

        public ServiceDetailRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        // Thêm mới chi tiết dịch vụ
        public bool Create(ServiceDetailModel serviceDetail)
        {
            string msgError = "";
            try
            {
                // Gọi stored procedure để tạo chi tiết dịch vụ
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_service_detail",
                    "@ServiceId", serviceDetail.ServiceId,
                    "@StepDescription", serviceDetail.StepDescription,
                    "@ImageDetails", serviceDetail.ImageDetails,
                    "@StepOrder", serviceDetail.StepOrder);

                if (!string.IsNullOrEmpty(msgError))
                {
                    Console.WriteLine("Stored Procedure Error: " + msgError); // Thông báo lỗi từ stored procedure
                    throw new Exception(msgError); // Ném ngoại lệ nếu có lỗi
                }

                if (result == null || string.IsNullOrEmpty(result.ToString()))
                {
                    Console.WriteLine("Stored Procedure returned no result."); // Thông báo nếu stored procedure không trả về kết quả
                    throw new Exception("Stored Procedure returned no result."); // Ném ngoại lệ nếu không có kết quả
                }

                Console.WriteLine("Result: " + result.ToString()); // In ra kết quả từ stored procedure
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating service detail: " + ex.Message); // Ném ngoại lệ với thông báo lỗi chi tiết
            }
        }

        // Cập nhật chi tiết dịch vụ
        public bool Update(ServiceDetailModel serviceDetail)
        {
            string msgError = "";
            try
            {
                // Gọi stored procedure để cập nhật chi tiết dịch vụ
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_service_detail",
                    "@ServiceDetailId", serviceDetail.ServiceDetailId,
                    "@ServiceId", serviceDetail.ServiceId,
                    "@StepDescription", serviceDetail.StepDescription,
                    "@ImageDetails", serviceDetail.ImageDetails,
                    "@StepOrder", serviceDetail.StepOrder);

                // Kiểm tra lỗi sau khi cập nhật chi tiết dịch vụ
                if (!string.IsNullOrEmpty(msgError) || (result != null && !string.IsNullOrEmpty(result.ToString())))
                {
                    throw new Exception(msgError + Convert.ToString(result));
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating service detail: " + ex.Message);
            }
        }

        // Xóa chi tiết dịch vụ
        public bool Delete(int serviceDetailId)
        {
            string msgError = "";
            try
            {
                // Xóa chi tiết dịch vụ
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_delete_service_detail",
                    "@ServiceDetailId", serviceDetailId);

                if (!string.IsNullOrEmpty(msgError) || (result != null && !string.IsNullOrEmpty(result.ToString())))
                {
                    throw new Exception(msgError + Convert.ToString(result));
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting service detail: " + ex.Message);
            }
        }

        // Lấy danh sách tất cả các chi tiết dịch vụ
        public List<ServiceDetailModel> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_all_service_details");

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<ServiceDetailModel>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting service details list: " + ex.Message);
            }
        }

        // Lấy thông tin chi tiết dịch vụ theo ID
        public ServiceDetailModel GetById(int serviceDetailId)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_service_detail_by_id", "@ServiceDetailId", serviceDetailId);

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                var serviceDetail = dt.ConvertTo<ServiceDetailModel>().FirstOrDefault();

                return serviceDetail;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting service detail by ID: " + ex.Message);
            }
        }
    }
}
