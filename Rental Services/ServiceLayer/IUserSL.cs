using Rental_Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Services.ServiceLayer
{
    public interface IUserSL
    {
        public Task<BasicResponse> AddBooking(AddBookingRequest request);

        public Task<BasicResponse> UpdateBooking(UpdateBookingRequest request);

        public Task<GetBookingResponse> GetBooking(int UserID, int PageNumber, int RecordPerPage);

        public Task<BasicResponse> DeleteBooking(int BookingID);
    }
}
