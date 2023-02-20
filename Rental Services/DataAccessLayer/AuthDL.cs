using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Rental_Services.Data;
using Rental_Services.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Services.DataAccessLayer
{
    public class AuthDL : IAuthDL
    {

        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _applicationDbContext;

        public AuthDL(IConfiguration configuration, ApplicationDbContext applicationDbContext)
        {
            _configuration = configuration;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<SignInResponse> SignIn(SignInRequest request)
        {
            SignInResponse response = new SignInResponse();
            response.IsSuccess = true;
            response.Message = "Sign In Successfully";

            try
            {

                var Result = _applicationDbContext
                    .AuthDetails
                    .Where(X => X.UserName.ToLower() == request.UserName.ToLower() &&
                    X.Password.ToLower() == request.Password.ToLower()).FirstOrDefault();

                if (Result == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Sign In Failed";
                    return response;
                }

                response.data = new UserDetailResponse();
                response.data.UserID = Result.UserID;
                response.data.UserName = Result.UserName;
                response.data.Role = Result.Role.ToUpper();
                response.data.Token = GenerateJwt(Result.UserID.ToString(), Result.UserName);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public async Task<BasicResponse> SignUp(SignUpRequest request)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Registration Successfully";

            try
            {
                bool Found = _applicationDbContext
                    .AuthDetails
                    .Any(X => X.UserName.ToLower() == request.UserName.ToLower());

                if (Found)
                {
                    response.IsSuccess = false;
                    response.Message = "UserName Or Email Already Exist";
                    return response;
                }

                AuthDetails authRequest = new AuthDetails()
                {
                    InsertionDate = DateTime.Now.ToString("dd-MMM-yyyy"),
                    UserName = request.UserName,
                    Password = request.Password,
                    Role = request.Role.ToString().ToUpper()
                };

                await _applicationDbContext.AuthDetails.AddAsync(authRequest);
                await _applicationDbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
        }

        public string GenerateJwt(string UserID, string Email)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
             new Claim(JwtRegisteredClaimNames.Sid, UserID),
             new Claim(JwtRegisteredClaimNames.Email, Email),
             //new Claim(ClaimTypes.Role,Role),
             new Claim("Date", DateTime.Now.ToString()),
             };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Audiance"],
              claims, 
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
