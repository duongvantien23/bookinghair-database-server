using DataAccessLayer;
using DataAcessLayer.InterFace;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAcessLayer
{
    public class CitiesRepository : ICitiesRepository
    {
        private readonly IDatabaseHelper _dbHelper;

        public CitiesRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        // Thêm thành phố mới
        public bool Create(CitiesModel city)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_city",
                    "@CityName", city.CityName);

                if (!string.IsNullOrEmpty(msgError) || (result != null && !string.IsNullOrEmpty(result.ToString())))
                {
                    throw new Exception(msgError + Convert.ToString(result));
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating city: " + ex.Message);
            }
        }

        // Cập nhật thành phố
        public bool Update(CitiesModel city)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_city",
                    "@CityId", city.CityId,
                    "@CityName", city.CityName);

                if (!string.IsNullOrEmpty(msgError) || (result != null && !string.IsNullOrEmpty(result.ToString())))
                {
                    throw new Exception(msgError + Convert.ToString(result));
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating city: " + ex.Message);
            }
        }

        // Xóa thành phố
        public bool Delete(int cityId)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_delete_city",
                    "@CityId", cityId);

                if (!string.IsNullOrEmpty(msgError) || (result != null && !string.IsNullOrEmpty(result.ToString())))
                {
                    throw new Exception(msgError + Convert.ToString(result));
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting city: " + ex.Message);
            }
        }

        // Lấy danh sách tất cả các thành phố
        public List<CitiesModel> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_all_cities");

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<CitiesModel>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting cities list: " + ex.Message);
            }
        }

        // Lấy thông tin thành phố theo ID
        public CitiesModel GetById(int cityId)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_city_by_id", "@CityId", cityId);

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<CitiesModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting city by ID: " + ex.Message);
            }
        }
    }
}
