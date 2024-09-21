using DataAccessLayer;
using DataAcessLayer.InterFace;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAcessLayer
{
    public class HairStylistRepository : IHairStylistRepository
    {
        private readonly IDatabaseHelper _dbHelper;

        public HairStylistRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(HairStylistModel hairstylist)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_hairstylist",
                    "@SalonId", hairstylist.SalonId,
                    "@NameStylist", hairstylist.NameStylist,
                    "@Phone", hairstylist.Phone,
                    "@MainImage", hairstylist.MainImage,
                    "@Salary", hairstylist.Salary);

                if (!string.IsNullOrEmpty(msgError) || (result != null && !string.IsNullOrEmpty(result.ToString())))
                {
                    throw new Exception(msgError + Convert.ToString(result));
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating hairstylist: " + ex.Message);
            }
        }

        public bool Update(HairStylistModel hairstylist)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_hairstylist",
                    "@HairstylistId", hairstylist.HairstylistId,
                    "@SalonId", hairstylist.SalonId,
                    "@NameStylist", hairstylist.NameStylist,
                    "@Phone", hairstylist.Phone,
                    "@MainImage", hairstylist.MainImage,
                    "@Salary", hairstylist.Salary);

                if (!string.IsNullOrEmpty(msgError) || (result != null && !string.IsNullOrEmpty(result.ToString())))
                {
                    throw new Exception(msgError + Convert.ToString(result));
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating hairstylist: " + ex.Message);
            }
        }

        public bool Delete(int hairstylistId)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_delete_hairstylist",
                    "@HairstylistId", hairstylistId);

                if (!string.IsNullOrEmpty(msgError) || (result != null && !string.IsNullOrEmpty(result.ToString())))
                {
                    throw new Exception(msgError + Convert.ToString(result));
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting hairstylist: " + ex.Message);
            }
        }

        public List<HairStylistModel> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_all_hairstylists");

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<HairStylistModel>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting hairstylists list: " + ex.Message);
            }
        }

        public HairStylistModel GetById(int hairstylistId)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_hairstylist_by_id", "@HairstylistId", hairstylistId);

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<HairStylistModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting hairstylist by ID: " + ex.Message);
            }
        }
    }
}
