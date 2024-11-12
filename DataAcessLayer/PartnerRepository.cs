using DataAccessLayer;
using DataAcessLayer.InterFace;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAcessLayer
{
    public class PartnerRepository : IPartnerRepository
    {
        private readonly IDatabaseHelper _dbHelper;

        public PartnerRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        // Thêm đối tác mới
        public bool Create(PartnerModel partner)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_partner",
                    "@PartnerName", partner.PartnerName,
                    "@Description", partner.Description,
                    "@Phone", partner.Phone,
                    "@Address", partner.Address,
                    "@Website", partner.Website);

                if (!string.IsNullOrEmpty(msgError) || string.IsNullOrEmpty(result?.ToString()))
                {
                    throw new Exception($"Stored Procedure Error: {msgError}");
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating partner: " + ex.Message);
            }
        }

        // Cập nhật đối tác
        public bool Update(PartnerModel partner)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_partner",
                    "@PartnerId", partner.PartnerId,
                    "@PartnerName", partner.PartnerName,
                    "@Description", partner.Description,
                    "@Phone", partner.Phone,
                    "@Address", partner.Address,
                    "@Website", partner.Website);

                if (!string.IsNullOrEmpty(msgError) || string.IsNullOrEmpty(result?.ToString()))
                {
                    throw new Exception($"Stored Procedure Error: {msgError}");
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating partner: " + ex.Message);
            }
        }

        // Xóa đối tác
        public bool Delete(int partnerId)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_delete_partner",
                    "@PartnerId", partnerId);

                if (!string.IsNullOrEmpty(msgError) || string.IsNullOrEmpty(result?.ToString()))
                {
                    throw new Exception($"Stored Procedure Error: {msgError}");
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting partner: " + ex.Message);
            }
        }

        // Lấy danh sách tất cả đối tác
        public List<PartnerModel> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_all_partners");

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<PartnerModel>()?.ToList() ?? new List<PartnerModel>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting partners list: " + ex.Message);
            }
        }

        // Lấy thông tin đối tác theo ID
        public PartnerModel GetById(int partnerId)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_partner_by_id", "@PartnerId", partnerId);

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<PartnerModel>()?.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting partner by ID: " + ex.Message);
            }
        }
    }
}
