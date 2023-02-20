
using Rental_Services.DataAccessLayer;
using Rental_Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Services.ServiceLayer
{
    public class AuthSL : IAuthSL
    {
        private readonly IAuthDL _authDL;
        public AuthSL(IAuthDL authDL)
        {
            _authDL = authDL;
        }

        public async Task<SignInResponse> SignIn(SignInRequest request)
        {
            return await _authDL.SignIn(request);
        }

        public async Task<BasicResponse> SignUp(SignUpRequest request)
        {
            return await _authDL.SignUp(request);
        }
    }
}
