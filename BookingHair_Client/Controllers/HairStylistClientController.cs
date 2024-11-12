using BusinessLayer.Interface;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookingHair_Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HairStylistClientController : ControllerBase
    {
        private readonly IHairStylistBusiness _hairStylistBusiness;

        public HairStylistClientController(IHairStylistBusiness hairStylistBusiness)
        {
            _hairStylistBusiness = hairStylistBusiness;
        }

        // GET: api/hairstylistclient/get-all
        [HttpGet("get-all")]
        public ActionResult<List<HairStylistModel>> GetAllHairStylists()
        {
            var hairstylists = _hairStylistBusiness.GetAllHairStylists();
            if (hairstylists == null || hairstylists.Count == 0)
            {
                return NotFound("No hairstylists found.");
            }
            return Ok(hairstylists);
        }

        // GET: api/hairstylistclient/get-by-id/{id}
        [HttpGet("get-by-id/{id}")]
        public ActionResult<HairStylistModel> GetHairStylistById(int id)
        {
            var hairstylist = _hairStylistBusiness.GetHairStylistById(id);
            if (hairstylist == null)
            {
                return NotFound($"HairStylist with ID {id} not found.");
            }
            return Ok(hairstylist);
        }
    }
}
