using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Services.Data
{
    public class AuthDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        public string InsertionDate { get; set; } = DateTime.Now.ToString("dd-MMM-yyyy");

        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }

    public class VehicleDetails
    {
        //VehicleID InsertionDate VehicleName VehicleNumber VehicleDescription TotalPrice
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleID { get; set; }

        public string InsertionDate { get; set; } = DateTime.Now.ToString("dd-MMM-yyyy");

        public string VehicleName { get; set; } = string.Empty;

        public string VehicleNumber { get; set; } = string.Empty;

        public string VehicleDescription { get; set; } = string.Empty;

        public int Price { get; set; }

        public string ImageUrl { get; set; }
    }

    public class BookingDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingID { get; set; }
        public string InsertionDate { get; set; } = DateTime.Now.ToString("dd-MMM-yyyy");
        public int UserID { get; set; }
        //Vehicle Detail
        // VehicleID, VehicleName, VehicleNumber, VehicleDescription, PricePerKm, ImageUrl
        public int VehicleID { get; set; }
        public string VehicleName { get; set; } = string.Empty;
        public string VehicleNumber { get; set; } = string.Empty;
        public string VehicleDescription { get; set; } = string.Empty;
        public int PricePerKm { get; set; }
        public string ImageUrl { get; set; }
        //
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int TotalPrice { get; set; }
        public string TotalDistance { get; set; }
        public string Status { get; set; }
        public string IsActive { get; set; }
    }

}
