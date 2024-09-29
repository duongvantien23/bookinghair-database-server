using DataAccessLayer;
using DataAcessLayer.InterFace;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAcessLayer
{
    public class SalonRepository : ISalonRepository
    {
        private readonly IDatabaseHelper _dbHelper;

        public SalonRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        // Thêm mới salon
        public bool Create(SalonModel salon)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_salon",
                    "@NameSalon", salon.NameSalon,
                    "@CityId", salon.CityId,
                    "@DistrictId", salon.DistrictId,
                    "@Address", salon.Address,
                    "@Phone", salon.Phone,
                    "@ImageSalon", salon.ImageSalon);

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
                throw new Exception("Error creating salon: " + ex.Message);
            }
        }
        // Cập nhật salon
        public bool Update(SalonModel salon)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_salon",
                    "@SalonId", salon.SalonId,
                    "@NameSalon", salon.NameSalon,
                    "@CityId", salon.CityId,
                    "@DistrictId", salon.DistrictId,
                    "@Address", salon.Address,
                    "@Phone", salon.Phone,
                    "@ImageSalon", salon.ImageSalon);

                if (!string.IsNullOrEmpty(msgError) || (result != null && !string.IsNullOrEmpty(result.ToString())))
                {
                    throw new Exception(msgError + Convert.ToString(result));
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating salon: " + ex.Message);
            }
        }

        // Xóa salon
        public bool Delete(int salonId)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_delete_salon",
                    "@SalonId", salonId);

                if (!string.IsNullOrEmpty(msgError) || (result != null && !string.IsNullOrEmpty(result.ToString())))
                {
                    throw new Exception(msgError + Convert.ToString(result));
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting salon: " + ex.Message);
            }
        }

        // Lấy danh sách tất cả salon
        public List<SalonModel> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_all_salons");

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<SalonModel>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting salons list: " + ex.Message);
            }
        }

        // Lấy thông tin salon theo ID
        public SalonModel GetById(int salonId)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_salon_by_id", "@SalonId", salonId);

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<SalonModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting salon by ID: " + ex.Message);
            }
        }
    }
}
