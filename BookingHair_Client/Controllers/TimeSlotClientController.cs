using BusinessLayer.Interface;
using DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookingHair_Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSlotClientController : ControllerBase
    {
        private readonly ITimeSlotBusiness _timeSlotBusiness;

        public TimeSlotClientController(ITimeSlotBusiness timeSlotBusiness)
        {
            _timeSlotBusiness = timeSlotBusiness;
        }

        // Route: GET api/timeslotclient/get-all
        [HttpGet("get-all")]
        public ActionResult<List<TimeSlotModel>> GetAllTimeSlots()
        {
            var timeSlots = _timeSlotBusiness.GetAllTimeSlots();
            if (timeSlots == null || timeSlots.Count == 0)
            {
                return NotFound("No time slots found.");
            }
            return Ok(timeSlots);
        }

        // Route: GET api/timeslotclient/get-by-id/{id}
        [HttpGet("get-by-id/{id}")]
        public ActionResult<TimeSlotModel> GetTimeSlotById(int id)
        {
            var timeSlot = _timeSlotBusiness.GetTimeSlotById(id);
            if (timeSlot == null)
            {
                return NotFound($"Time slot with ID {id} not found.");
            }
            return Ok(timeSlot);
        }

        // Route: GET api/timeslotclient/get-by-salon-id/{salonId}
        [HttpGet("get-by-salon-id/{salonId}")]
        public ActionResult<List<TimeSlotModel>> GetTimeSlotsBySalonId(int salonId)
        {
            var timeSlots = _timeSlotBusiness.GetTimeSlotsBySalonId(salonId);
            if (timeSlots == null || timeSlots.Count == 0)
            {
                return NotFound($"No time slots found for Salon ID {salonId}.");
            }
            return Ok(timeSlots);
        }
        // Route: GET api/timeslotclient/get-today/{salonId}
        [HttpGet("get-today/{salonId}")]
        public ActionResult<List<TimeSlotModel>> GetTimeSlotsForToday(int salonId)
        {
            var timeSlots = _timeSlotBusiness.GetTimeSlotsForToday(salonId);
            if (timeSlots == null || timeSlots.Count == 0)
            {
                return NotFound($"No time slots found for today at Salon ID {salonId}.");
            }
            return Ok(timeSlots);
        }

        // Route: GET api/timeslotclient/get-tomorrow/{salonId}
        [HttpGet("get-tomorrow/{salonId}")]
        public ActionResult<List<TimeSlotModel>> GetTimeSlotsForTomorrow(int salonId)
        {
            var timeSlots = _timeSlotBusiness.GetTimeSlotsForTomorrow(salonId);
            if (timeSlots == null || timeSlots.Count == 0)
            {
                return NotFound($"No time slots found for tomorrow at Salon ID {salonId}.");
            }
            return Ok(timeSlots);
        }
    }
}
