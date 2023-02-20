using Rental_Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Services.DataAccessLayer
{
   public interface IAuthDL
    {
        public Task<SignInResponse> SignIn(SignInRequest request);
        public Task<BasicResponse> SignUp(SignUpRequest request);
    }
}
