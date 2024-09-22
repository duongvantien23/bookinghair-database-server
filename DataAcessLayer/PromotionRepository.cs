using DataAccessLayer;
using DataAcessLayer.InterFace;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAcessLayer
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly IDatabaseHelper _dbHelper;

        public PromotionRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        // Thêm mới khuyến mãi
        public bool Create(PromotionModel promotion)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_promotion",
                    "@NamePromo", promotion.NamePromo,
                    "@Description", promotion.Description,
                    "@Image", promotion.Image,
                    "@Discount", promotion.Discount,
                    "@StartDate", promotion.StartDate,
                    "@EndDate", promotion.EndDate);

                if (!string.IsNullOrEmpty(msgError) || result == null)
                {
                    throw new Exception(msgError);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating promotion: " + ex.Message);
            }
        }

        // Cập nhật khuyến mãi
        public bool Update(PromotionModel promotion)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_promotion",
                    "@PromotionId", promotion.PromotionId,
                    "@NamePromo", promotion.NamePromo,
                    "@Description", promotion.Description,
                    "@Image", promotion.Image,
                    "@Discount", promotion.Discount,
                    "@StartDate", promotion.StartDate,
                    "@EndDate", promotion.EndDate);

                if (!string.IsNullOrEmpty(msgError) || result == null)
                {
                    throw new Exception(msgError);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating promotion: " + ex.Message);
            }
        }

        // Xóa khuyến mãi
        public bool Delete(int promotionId)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_delete_promotion",
                    "@PromotionId", promotionId);

                if (!string.IsNullOrEmpty(msgError) || result == null)
                {
                    throw new Exception(msgError);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting promotion: " + ex.Message);
            }
        }

        // Lấy danh sách tất cả các khuyến mãi
        public List<PromotionModel> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_all_promotions");

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<PromotionModel>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting promotion list: " + ex.Message);
            }
        }

        // Lấy khuyến mãi theo ID
        public PromotionModel GetById(int promotionId)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_promotion_by_id", "@PromotionId", promotionId);

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<PromotionModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting promotion by ID: " + ex.Message);
            }
        }
    }
}
