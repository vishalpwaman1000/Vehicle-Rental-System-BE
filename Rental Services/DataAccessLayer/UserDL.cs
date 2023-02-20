using Microsoft.Extensions.Configuration;
using Rental_Services.Data;
using Rental_Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Services.DataAccessLayer
{
    public class UserDL : IUserDL
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _applicationDbContext;

        public UserDL(IConfiguration configuration, ApplicationDbContext applicationDbContext)
        {
            _configuration = configuration;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<BasicResponse> AddBooking(AddBookingRequest request)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Add Booking Successfully";
            try
            {


                BookingDetails data = new BookingDetails()
                {
                    InsertionDate = DateTime.Now.ToString("dd-MMM-yyyy"),
                    UserID= request.UserID,
                    CustomerName = request.CustomerName,
                    MobileNumber = request.MobileNumber,
                    Source = request.Source,
                    Destination = request.Destination,
                    TotalPrice = request.TotalPrice,
                    TotalDistance = request.TotalDistance,
                    Status = request.Status,
                    // VehicleID, VehicleName, VehicleNumber, VehicleDescription, PricePerKm, ImageUrl
                    VehicleID = request.VehicleID,
                    VehicleName = request.VehicleName,
                    VehicleNumber = request.VehicleNumber,
                    VehicleDescription = request.VehicleDescription,
                    PricePerKm = request.PricePerKm,
                    ImageUrl = request.ImageUrl
                };

                await _applicationDbContext.BookingDetails.AddAsync(data);
                int Result = await _applicationDbContext.SaveChangesAsync();
                if (Result <= 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Something Went Wrong";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public async Task<BasicResponse> DeleteBooking(int BookingID)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Cancel Booking Successfully";
            try
            {
                var Result = _applicationDbContext
                    .BookingDetails
                    .Where(X => X.BookingID == BookingID).FirstOrDefault();

                if (Result == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Record Is Not Found.";
                    return response;
                }

                Result.Status = "cancel";

                await _applicationDbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public async Task<GetBookingResponse> GetBooking(int UserID, int PageNumber, int RecordPerPage)
        {
            GetBookingResponse response = new GetBookingResponse();
            response.IsSuccess = true;
            response.Message = "Get Booking List Successfully";
            try
            {
                response.data = new List<BookingDetails>();
                response.data = _applicationDbContext
                    .BookingDetails.Where(X=>X.UserID==UserID)
                    .Skip((PageNumber - 1) * RecordPerPage)
                    .Take(RecordPerPage)
                    .OrderByDescending(X => X.BookingID)
                    .ToList();

                if (response.data.Count == 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Record Is Not Found.";
                    return response;
                }

                double TotalRecord = _applicationDbContext
                                    .BookingDetails
                                    .Count();

                response.TotalPages = (int)Math.Ceiling((double)(TotalRecord / RecordPerPage));

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public async Task<BasicResponse> UpdateBooking(UpdateBookingRequest request)
        {

            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Update Booking Successfully";
            try
            {

                var data = _applicationDbContext.BookingDetails.FindAsync(request.BookingID);
                if (data.Result == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Booking ID Not Found.";
                    return response;
                }

                //UserID, CustomerName, MobileNumber, Source, Destination, TotalPrice, TotalDistance, Status
                data.Result.UserID = request.UserID;
                data.Result.TotalPrice = request.Price;
                data.Result.CustomerName = request.CustomerName;
                data.Result.MobileNumber = request.MobileNumber;
                data.Result.Source = request.Source;
                data.Result.Destination = request.Destination;
                data.Result.TotalDistance = request.TotalDistance;
                data.Result.Status = request.Status;
                // VehicleID, VehicleName, VehicleNumber, VehicleDescription, PricePerKm, ImageUrl
                data.Result.VehicleID = request.VehicleID;
                data.Result.VehicleName = request.VehicleName;
                data.Result.VehicleNumber = request.VehicleNumber;
                data.Result.VehicleDescription = request.VehicleDescription;
                data.Result.PricePerKm = request.PricePerDay;
                data.Result.ImageUrl = request.ImageUrl;

                await _applicationDbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;

        }
    }
}
