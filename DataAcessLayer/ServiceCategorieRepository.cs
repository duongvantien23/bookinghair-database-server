using System;
using System.Collections.Generic;
using DataModel;
using DataAcessLayer.InterFace;
using DataAccessLayer;

namespace DataAcessLayer
{
    public class ServiceCategoryRepository : IServiceCategorieRepository
    {
        private readonly IDatabaseHelper _dbHelper;

        public ServiceCategoryRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(ServiceCategorieModel category)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_service_category",
                    "@CategoryName", category.CategoryName,
                    "@Description", category.Description,
                    "@ImageServiceCategory", category.ImageServiceCategory);

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception("Stored Procedure Error: " + msgError);
                }

                if (result == null || string.IsNullOrEmpty(result.ToString()))
                {
                    throw new Exception("Stored Procedure returned no result.");
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating service category: " + ex.Message);
            }
        }
        // Cập nhật danh mục dịch vụ
        public bool Update(ServiceCategorieModel category)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_service_category",
                    "@CategoryId", category.CategoryId,
                    "@CategoryName", category.CategoryName,
                    "@Description", category.Description,
                    "@ImageServiceCategory", category.ImageServiceCategory);

                // Kiểm tra lỗi từ stored procedure và kết quả trả về
                if (!string.IsNullOrEmpty(msgError) || (result != null && !string.IsNullOrEmpty(result.ToString())))
                {
                    throw new Exception(msgError + Convert.ToString(result));
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating service category: " + ex.Message);
            }
        }

        // Xóa danh mục dịch vụ
        public bool Delete(int categoryId)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_delete_service_category",
                    "@CategoryId", categoryId);

                if (!string.IsNullOrEmpty(msgError) || (result != null && !string.IsNullOrEmpty(result.ToString())))
                {
                    throw new Exception(msgError + Convert.ToString(result));
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting service category: " + ex.Message);
            }
        }

        // Lấy tất cả danh mục dịch vụ
        public List<ServiceCategorieModel> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_all_service_categories");

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<ServiceCategorieModel>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting service categories list: " + ex.Message);
            }
        }

        // Lấy danh mục dịch vụ theo ID
        public ServiceCategorieModel GetById(int categoryId)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_service_category_by_id", "@CategoryId", categoryId);

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                var category = dt.ConvertTo<ServiceCategorieModel>().FirstOrDefault();

                return category;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting service category by ID: " + ex.Message);
            }
        }
        public List<ServiceModel> GetServicesByCategoryId(int categoryId)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_services_by_category_id", "@CategoryId", categoryId);

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<ServiceModel>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting services by category ID: " + ex.Message);
            }
        }
    }
}
