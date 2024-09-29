using DataAccessLayer;
using DataAcessLayer.InterFace;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAcessLayer
{
    public class CustomerReviewRepository : ICustomerReviewRepository
    {
        private readonly IDatabaseHelper _dbHelper;

        public CustomerReviewRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        // Thêm mới đánh giá khách hàng
        public bool Create(CustomerReviewModel review)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_customer_review",
                    "@CustomerId", review.CustomerId,
                    "@ServiceId", review.ServiceId,
                    "@Rating", review.Rating,
                    "@Comment", review.Comment);

                if (!string.IsNullOrEmpty(msgError) || result == null)
                {
                    throw new Exception(msgError);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating customer review: " + ex.Message);
            }
        }

        // Cập nhật đánh giá khách hàng
        public bool Update(CustomerReviewModel review)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_customer_review",
                    "@ReviewId", review.ReviewId,
                    "@CustomerId", review.CustomerId,
                    "@ServiceId", review.ServiceId,
                    "@Rating", review.Rating,
                    "@Comment", review.Comment);

                if (!string.IsNullOrEmpty(msgError) || result == null)
                {
                    throw new Exception(msgError);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating customer review: " + ex.Message);
            }
        }

        // Xóa đánh giá khách hàng
        public bool Delete(int reviewId)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_delete_customer_review",
                    "@ReviewId", reviewId);

                if (!string.IsNullOrEmpty(msgError) || result == null)
                {
                    throw new Exception(msgError);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting customer review: " + ex.Message);
            }
        }

        // Lấy tất cả các đánh giá khách hàng
        public List<CustomerReviewModel> GetAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_all_customer_reviews");

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<CustomerReviewModel>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting customer reviews list: " + ex.Message);
            }
        }

        // Lấy đánh giá khách hàng theo ID
        public CustomerReviewModel GetById(int reviewId)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_customer_review_by_id", "@ReviewId", reviewId);

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<CustomerReviewModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting customer review by ID: " + ex.Message);
            }
        }

        // Lấy tất cả các đánh giá của một dịch vụ cụ thể
        public List<CustomerReviewModel> GetByServiceId(int serviceId)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_reviews_by_service", "@ServiceId", serviceId);

                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                return dt.ConvertTo<CustomerReviewModel>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting reviews by service: " + ex.Message);
            }
        }
    }
}
