using BusinessLayer.Interface;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Booking_Hair_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerBusiness _partnerBusiness;

        public PartnerController(IPartnerBusiness partnerBusiness)
        {
            _partnerBusiness = partnerBusiness;
        }

        // GET: api/Partner
        [HttpGet("get-all")]
        public IActionResult GetAllPartners()
        {
            try
            {
                var partners = _partnerBusiness.GetAllPartners();
                return Ok(partners);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/Partner/{id}
        [HttpGet("get-by-id/{id}")]
        public IActionResult GetPartnerById(int id)
        {
            try
            {
                var partner = _partnerBusiness.GetPartnerById(id);
                if (partner == null)
                    return NotFound("Partner not found");

                return Ok(partner);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST: api/Partner
        [HttpPost("create")]
        public IActionResult CreatePartner([FromBody] PartnerModel partner)
        {
            try
            {
                if (partner == null)
                    return BadRequest("Partner is null");

                var isCreated = _partnerBusiness.CreatePartner(partner);
                if (isCreated)
                    return StatusCode(StatusCodes.Status201Created);

                return BadRequest("Failed to create partner");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/Partner/{id}
        [HttpPut("update")]
        public IActionResult UpdatePartner(int id, [FromBody] PartnerModel partner)
        {
            try
            {
                if (partner == null || partner.PartnerId != id)
                    return BadRequest("Partner data is invalid");

                var isUpdated = _partnerBusiness.UpdatePartner(partner);
                if (isUpdated)
                    return NoContent();

                return NotFound("Partner not found");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE: api/Partner/{id}
        [HttpDelete("delete/{id}")]
        public IActionResult DeletePartner(int id)
        {
            try
            {
                var isDeleted = _partnerBusiness.DeletePartner(id);
                if (isDeleted)
                    return NoContent();

                return NotFound("Partner not found");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
