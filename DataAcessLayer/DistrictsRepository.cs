using DataAccessLayer;
using DataAcessLayer.InterFace;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAcessLayer
{
    public class DistrictsRepository : IDistrictsRepository
    {
        private readonly IDatabaseHelper _dbHelper;

        public DistrictsRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        // Thêm huyện/quận mới
        public bool Create(DistrictsModel district)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_district",
                    "@DistrictName", district.DistrictName,
                    "@CityId", district.CityId);

                if (!string.IsNullOrEmpty(msgError))
                {
                    Console.WriteLine("Stored Procedure Error: " + msgError);  
                    throw new Exception(msgError); 
                }

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
                throw new Exception("Error creating district: " + ex.Message); 
            }
        }
        // Cập nhật huyện/quận
        public bool Update(DistrictsModel district)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_district",
                    "@DistrictId", district.DistrictId,
                    "@DistrictName", district.DistrictName,
                    "@CityId", district.CityId);

                if (!string.IsNullOrEmpty(msgError) || (result != null && !string.IsNullOrEmpty(result.ToString())))
                {
                    throw new Exception(msgError + Convert.ToString(result));
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating district: " + ex.Message);
            }
        }

        // Xóa huyện/quận
        public bool Delete(int districtId)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_delete_district",
                    "@DistrictId", districtId);

                if (!string.IsNullOrEmpty(msgError) || (result != null && !string.IsNullOrEmpty(result.ToString())))
                {
                    throw new Exception(msgError + Convert.ToString(result));
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting district: " + ex.Message);
            }
        }

        // Lấy danh sách tất cả huyện/quận
        public List<DistrictsModel> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_all_districts");

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<DistrictsModel>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting districts list: " + ex.Message);
            }
        }

        // Lấy thông tin huyện/quận theo ID
        public DistrictsModel GetById(int districtId)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_district_by_id", "@DistrictId", districtId);

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<DistrictsModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting district by ID: " + ex.Message);
            }
        }
    }
}
