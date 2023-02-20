
using Rental_Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Services.ServiceLayer
{
    public interface IAuthSL
    {
        public Task<SignInResponse> SignIn(SignInRequest request);
        public Task<BasicResponse> SignUp(SignUpRequest request);
    }
}
