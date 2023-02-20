using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental_Services.Model;
using Rental_Services.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Services.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminSL _adminSL;
        public AdminController(IAdminSL adminSL) 
        {
            _adminSL = adminSL;
        }

        [HttpPost]
        public async Task<IActionResult> AddVehicle([FromForm] AddVehicleRequest request)
        {
            BasicResponse response = new BasicResponse();

            try 
            {
                response = await _adminSL.AddVehicle(request);
            }
            catch(Exception ex) 
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVehicle(UpdateVehicleRequest request)
        {
            BasicResponse response = new BasicResponse();

            try
            {
                response = await _adminSL.UpdateVehicle(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetVehicle([FromQuery] int PageNumber, int RecordPerPage)
        {
            GetVehicle response = new GetVehicle();

            try
            {
                response = await _adminSL.GetVehicle(PageNumber, RecordPerPage);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVehicle([FromQuery] int VehicleID)
        {
            BasicResponse response = new BasicResponse();

            try
            {
                response = await _adminSL.DeleteVehicle(VehicleID);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooking([FromQuery]int PageNumber, int RecordPerPage)
        {
            GetBookingResponse response = new GetBookingResponse();

            try
            {
                response = await _adminSL.GetAllBooking(PageNumber, RecordPerPage);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateBookingStatus([FromQuery]int BookingID, string Status)
        {
            BasicResponse response = new BasicResponse();

            try
            {
                response = await _adminSL.UpdateBookingStatus(BookingID, Status);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetGraph()
        {
            GetGraphResponse response = new GetGraphResponse();

            try
            {
                response = await _adminSL.GetGraph();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }


    }
}
