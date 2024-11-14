using BusinessLayer.Interface;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BookingHair_Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerClientController : ControllerBase
    {
        private readonly IPartnerBusiness _partnerBusiness;

        public PartnerClientController(IPartnerBusiness partnerBusiness)
        {
            _partnerBusiness = partnerBusiness;
        }

        // GET: api/PartnerClient/get-all
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

        // GET: api/PartnerClient/get-by-id/{id}
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
    }
}
