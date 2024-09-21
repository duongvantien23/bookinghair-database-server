using DataAccessLayer;
using DataAcessLayer.InterFace;
using DataModel;
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

        // Thêm mới dịch vụ và chi tiết dịch vụ
        public bool Create(ServiceModel service)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_service",
                    "@NameService", service.NameService,
                    "@Description", service.Description,
                    "@ImageService", service.ImageService,
                    "@Price", service.Price);

                if (!string.IsNullOrEmpty(msgError) || (result != null && !string.IsNullOrEmpty(result.ToString())))
                {
                    throw new Exception(msgError + Convert.ToString(result));
                }

                // Lấy ID của dịch vụ vừa tạo
                int serviceId = Convert.ToInt32(result);

                // Thêm chi tiết dịch vụ
                foreach (var detail in service.ListJsonDetailService)
                {
                    var detailResult = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_service_detail",
                        "@ServiceId", serviceId,
                        "@StepDescription", detail.StepDescription,
                        "@ImageDetails", detail.ImageDetails,
                        "@StepOrder", detail.StepOrder);

                    if (!string.IsNullOrEmpty(msgError) || (detailResult != null && !string.IsNullOrEmpty(detailResult.ToString())))
                    {
                        throw new Exception(msgError + Convert.ToString(detailResult));
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating service with details: " + ex.Message);
            }
        }

        // Cập nhật dịch vụ và chi tiết dịch vụ
        public bool Update(ServiceModel service)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_service",
                    "@ServiceId", service.ServiceId,
                    "@NameService", service.NameService,
                    "@Description", service.Description,
                    "@ImageService", service.ImageService,
                    "@Price", service.Price);

                if (!string.IsNullOrEmpty(msgError) || (result != null && !string.IsNullOrEmpty(result.ToString())))
                {
                    throw new Exception(msgError + Convert.ToString(result));
                }

                // Cập nhật chi tiết dịch vụ
                foreach (var detail in service.ListJsonDetailService)
                {
                    var detailResult = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_service_detail",
                        "@ServiceDetailId", detail.ServiceDetailId,
                        "@ServiceId", service.ServiceId,
                        "@StepDescription", detail.StepDescription,
                        "@ImageDetails", detail.ImageDetails,
                        "@StepOrder", detail.StepOrder);

                    if (!string.IsNullOrEmpty(msgError) || (detailResult != null && !string.IsNullOrEmpty(detailResult.ToString())))
                    {
                        throw new Exception(msgError + Convert.ToString(detailResult));
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating service with details: " + ex.Message);
            }
        }

        // Xóa dịch vụ và chi tiết dịch vụ
        public bool Delete(int serviceId)
        {
            string msgError = "";
            try
            {
                // Xóa chi tiết dịch vụ trước
                var detailResult = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_delete_service_details_by_service_id",
                    "@ServiceId", serviceId);

                if (!string.IsNullOrEmpty(msgError) || (detailResult != null && !string.IsNullOrEmpty(detailResult.ToString())))
                {
                    throw new Exception(msgError + Convert.ToString(detailResult));
                }

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

        // Lấy thông tin dịch vụ và chi tiết dịch vụ theo ID
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

                if (service != null)
                {
                    // Lấy chi tiết dịch vụ
                    var detailDt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_service_details_by_service_id", "@ServiceId", serviceId);

                    if (!string.IsNullOrEmpty(msgError))
                    {
                        throw new Exception(msgError);
                    }

                    service.ListJsonDetailService = detailDt.ConvertTo<ServiceDetailModel>().ToList();
                }

                return service;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting service by ID: " + ex.Message);
            }
        }
    }
}
