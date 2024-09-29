using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using DataModel;
using DataAcessLayer.InterFace;
using DataModel;

namespace Booking_Hair_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionRepository _promotionRepository;

        public PromotionController(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        // Lấy danh sách tất cả khuyến mãi
        [HttpGet("get-all")]
        public ActionResult<List<PromotionModel>> GetAllPromotions()
        {
            try
            {
                var promotions = _promotionRepository.GetAll();
                return Ok(promotions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Lấy khuyến mãi theo ID
        [HttpGet("get-by-id/{id}")]
        public ActionResult<PromotionModel> GetPromotionById(int id)
        {
            try
            {
                var promotion = _promotionRepository.GetById(id);
                if (promotion == null)
                    return NotFound("Promotion not found");

                return Ok(promotion);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Tạo mới khuyến mãi
        [HttpPost("create")]
        public ActionResult CreatePromotion([FromBody] PromotionModel promotion)
        {
            try
            {
                var result = _promotionRepository.Create(promotion);
                if (result)
                    return Ok("Promotion created successfully");

                return BadRequest("Failed to create promotion");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Cập nhật khuyến mãi
        [HttpPut("update")]
        public ActionResult UpdatePromotion([FromBody] PromotionModel promotion)
        {
            try
            {
                var result = _promotionRepository.Update(promotion);
                if (result)
                    return Ok("Promotion updated successfully");

                return BadRequest("Failed to update promotion");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Xóa khuyến mãi theo ID
        [HttpDelete("delete/{id}")]
        public ActionResult DeletePromotion(int id)
        {
            try
            {
                var result = _promotionRepository.Delete(id);
                if (result)
                    return Ok("Promotion deleted successfully");

                return BadRequest("Failed to delete promotion");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
