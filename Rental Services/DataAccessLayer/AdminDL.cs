using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Configuration;
using Rental_Services.Data;
using Rental_Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Services.DataAccessLayer
{
    public class AdminDL : IAdminDL
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IConfiguration _configuration;
        public AdminDL(ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            _applicationDbContext = applicationDbContext;
            _configuration = configuration;
        }

        public async Task<BasicResponse> AddVehicle(AddVehicleRequest request)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Add Vehicle Successfully";
            try
            {
                Account account = new Account(
                                _configuration["CloudinarySettings:CloudName"],
                                _configuration["CloudinarySettings:ApiKey"],
                                _configuration["CloudinarySettings:ApiSecret"]);


                Cloudinary cloudinary = new Cloudinary(account);
                var path = request.File.OpenReadStream();
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(request.File.FileName, path)
                };

                var uploadResult = cloudinary.Upload(uploadParams);
                //FileUrl = uploadResult.Url.ToString();

                VehicleDetails data = new VehicleDetails()
                {
                    InsertionDate = DateTime.Now.ToString("dd-MMM-yyyy"),
                    VehicleName = request.VehicleName,
                    VehicleNumber = request.VehicleNumber,
                    VehicleDescription = request.VehicleDescription,
                    ImageUrl = uploadResult.Url.ToString(),
                    Price = request.Price
                };

                await _applicationDbContext.VehicleDetails.AddAsync(data);
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

        public async Task<BasicResponse> UpdateVehicle(UpdateVehicleRequest request)
        {

            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Update Vehicle Successfully";
            try
            {

                var data = _applicationDbContext.VehicleDetails.FindAsync(request.VehicleID);
                if (data.Result == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Vehicle ID Not Found.";
                    return response;
                }

                data.Result.ImageUrl = request.ImageUrl;
                data.Result.Price = request.Price;
                data.Result.VehicleDescription = request.VehicleDescription;
                data.Result.VehicleName = request.VehicleName;
                data.Result.VehicleNumber = request.VehicleName;

                await _applicationDbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;

        }

        public async Task<GetVehicle> GetVehicle(int PageNumber, int RecordPerPage)
        {

            GetVehicle response = new GetVehicle();
            response.IsSuccess = true;
            response.Message = "Get Vehicle List Successfully";
            try
            {
                response.data = new List<VehicleDetails>();
                response.data = _applicationDbContext
                    .VehicleDetails
                    .Skip((PageNumber - 1) * RecordPerPage)
                    .Take(RecordPerPage)
                    .OrderByDescending(X => X.VehicleID)
                    .ToList();

                if (response.data.Count == 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Record Is Not Found.";
                    return response;
                }

                double TotalRecord = _applicationDbContext
                                    .VehicleDetails
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

        public async Task<BasicResponse> DeleteVehicle(int VehicleID)
        {

            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Delete Vehicle Successfully";
            try
            {
                var data = _applicationDbContext
                    .VehicleDetails
                    .Where(X => X.VehicleID == VehicleID)
                    .FirstOrDefault();

                if (data == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Vehicle ID Not Found";
                    return response;
                }
                _applicationDbContext.VehicleDetails.Remove(data);
                int DeleteResult = await _applicationDbContext.SaveChangesAsync();
                if (DeleteResult <= 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Something went Wrong";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;

        }

        public async Task<GetBookingResponse> GetAllBooking(int PageNumber, int RecordPerPage)
        {
            GetBookingResponse response = new GetBookingResponse();
            response.IsSuccess = true;
            response.Message = "Get Booking List Successfully";
            try
            {
                response.data = new List<BookingDetails>();
                response.data = _applicationDbContext
                    .BookingDetails
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

        public async Task<BasicResponse> UpdateBookingStatus(int BookingID, string Status)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Update Booking Status Successfully";
            try
            {

                var data = _applicationDbContext.BookingDetails.FindAsync(BookingID);
                if (data.Result == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Booking ID Not Found.";
                    return response;
                }

                data.Result.Status = Status;

                await _applicationDbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public async Task<GetGraphResponse> GetGraph()
        {
            GetGraphResponse response = new GetGraphResponse();
            response.IsSuccess = true;
            response.Message = "Delete Vehicle Successfully";
            try
            {

                response.PendingData = new List<GetGraph>();

                response.PendingData = AssignDefaultData();
                response.SuccessData = AssignDefaultData();
                response.CancelData = AssignDefaultData();
                response.RejectData = AssignDefaultData();

                var bookingData = _applicationDbContext
                                            .BookingDetails.ToList();

                foreach (var data in bookingData)
                {
                    string[] Month = data.InsertionDate.Split("-");
                    if (data.Status == "pending")
                    {
                        var Record = response.PendingData.Find(X => X.label.ToLower() == Month[1].ToLower());
                        Record.value += 1;
                    }
                    if (data.Status == "accept") 
                    {
                        var Record = response.SuccessData.Find(X => X.label.ToLower() == Month[1].ToLower());
                        Record.value += 1;
                    }
                    if (data.Status == "reject") 
                    {
                        var Record = response.RejectData.Find(X => X.label.ToLower() == Month[1].ToLower());
                        Record.value += 1;
                    }
                    if (data.Status == "cancel") 
                    {
                        var Record = response.CancelData.Find(X => X.label.ToLower() == Month[1].ToLower());
                        Record.value += 1;
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public List<GetGraph> AssignDefaultData()
        {
            List<GetGraph> response = new List<GetGraph>();

            try
            {

                response.Add(new GetGraph()
                {
                    label = "Jan",
                    value = 0
                });
                response.Add(new GetGraph()
                {
                    label = "Feb",
                    value = 0
                });
                response.Add(new GetGraph()
                {
                    label = "Mar",
                    value = 0
                });
                response.Add(new GetGraph()
                {
                    label = "Apr",
                    value = 0
                });
                response.Add(new GetGraph()
                {
                    label = "May",
                    value = 0
                });
                response.Add(new GetGraph()
                {
                    label = "June",
                    value = 0
                });
                response.Add(new GetGraph()
                {
                    label = "July",
                    value = 0
                });
                response.Add(new GetGraph()
                {
                    label = "Aug",
                    value = 0
                });
                response.Add(new GetGraph()
                {
                    label = "Sep",
                    value = 0
                });
                response.Add(new GetGraph()
                {
                    label = "Oct",
                    value = 0
                });
                response.Add(new GetGraph()
                {
                    label = "Nov",
                    value = 0
                });
                response.Add(new GetGraph()
                {
                    label = "Dec",
                    value = 0
                });

            }
            catch (Exception ex)
            {
                return null;
            }

            return response;

        }
    }
}
