using Rental_Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Services.Model
{
    public class AddBookingRequest
    {
        //UserID, CustomerName, MobileNumber, Source, Destination, TotalPrice, TotalDistance, Status
        public int UserID { get; set; }
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int TotalPrice { get; set; }
        public string TotalDistance { get; set; }
        public string Status { get; set; }
        // VehicleID, VehicleName, VehicleNumber, VehicleDescription, PricePerKm, ImageUrl
        public int VehicleID { get; set; }
        public string VehicleName { get; set; } = string.Empty;
        public string VehicleNumber { get; set; } = string.Empty;
        public string VehicleDescription { get; set; } = string.Empty;
        public int PricePerKm { get; set; }
        public string ImageUrl { get; set; }
    }


    public class UpdateBookingRequest
    {
        //UserID, CustomerName, MobileNumber, Source, Destination, TotalPrice, TotalDistance, Status
        public int BookingID { get; set; }
        public int UserID { get; set; }
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int Price { get; set; }
        public string TotalDistance { get; set; }
        public string Status { get; set; }
        // VehicleID, VehicleName, VehicleNumber, VehicleDescription, PricePerKm, ImageUrl
        public int VehicleID { get; set; }
        public string VehicleName { get; set; } = string.Empty;
        public string VehicleNumber { get; set; } = string.Empty;
        public string VehicleDescription { get; set; } = string.Empty;
        public int PricePerDay { get; set; }
        public string ImageUrl { get; set; }
    }

    public class GetBookingResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int TotalPages { get; set; }
        public List<BookingDetails> data { get; set; }
    }
}
