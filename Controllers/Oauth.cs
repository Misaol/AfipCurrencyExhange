using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Business.Dto.Response;
using Business.Dto.Request;
using Business.Services;
using Business.Security;

namespace AfipCurrencyExhange.Controllers
{
    public class Oauth : Controller
    {
        private readonly ILoginService _user;
        public Oauth(ILoginService user)
        {
            _user = user;
        }
        [HttpPost("Login")]
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            try
            {
                var token = await _user.Login(request);
                return new LoginResponse { Estado = 200, token = token.token, Message = token.Message };
            }
            catch (Exception e)
            {
                return new LoginResponse { Estado = 502, Message = e.Message };
            }
        }
        [HttpPost("Register")]
        public async Task<LoginResponse> Register(RegisterRequest request)
        {
            try
            {
                var register = await _user.Register(request);
                return new LoginResponse { Estado = register.Estado, Message = register.Message };
            }
            catch (Exception e)
            {
                return new LoginResponse { Estado = 500, Message = "error al hacer el request" + e.Message };
            }
        }
    }
}
