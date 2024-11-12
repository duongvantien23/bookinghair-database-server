using BusinessLayer.Interface;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookingHair_Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalonClientController : ControllerBase
    {
        private readonly ISalonBusiness _salonBusiness;

        public SalonClientController(ISalonBusiness salonBusiness)
        {
            _salonBusiness = salonBusiness;
        }

        // Route: GET api/salonclient/get-all
        [HttpGet("get-all")]
        public ActionResult<List<SalonModel>> GetAllSalons()
        {
            var salons = _salonBusiness.GetAllSalons();
            if (salons == null || salons.Count == 0)
            {
                return NotFound("No salons found.");
            }
            return Ok(salons);
        }

        // Route: GET api/salonclient/get-by-id/{id}
        [HttpGet("get-by-id/{id}")]
        public ActionResult<SalonModel> GetSalonById(int id)
        {
            var salon = _salonBusiness.GetSalonById(id);
            if (salon == null)
            {
                return NotFound($"Salon with ID {id} not found.");
            }
            return Ok(salon);
        }
        // Route: GET api/salonclient/get-by-district/{districtId}
        [HttpGet("get-by-district/{districtId}")]
        public ActionResult<List<SalonModel>> GetSalonsByDistrictId(int districtId)
        {
            var salons = _salonBusiness.GetSalonsByDistrictId(districtId);
            if (salons == null || salons.Count == 0)
            {
                return NotFound("No salons found for this district.");
            }
            return Ok(salons);
        }
    }
}
