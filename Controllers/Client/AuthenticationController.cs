using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using post_office.Models;
using Microsoft.AspNetCore.Authorization;
using post_office.Services;
using post_office.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Options;

namespace post_office.Controllers.Client
{
    public class AuthenticationController : Controller
    {
        private readonly ILogger<AuthenticationController> _logger;
        private ICustomerService _customerService;
        private readonly AppSettings _appSettings;

        public AuthenticationController(ILogger<AuthenticationController> logger, 
        ICustomerService customerService, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _customerService = customerService;
            _appSettings = appSettings.Value;
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register([FromBody] CustomerSignUpModel model){
            try {
                if (string.IsNullOrWhiteSpace(model.Password))
                    throw new AppException("Password is required");

                byte[] passwordHash, passwordSalt;
                Helpers.Helpers.CreatePasswordHash(model.Password, out passwordHash, out passwordSalt);
                var customer = new {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Phone = model.Phone,
                    Email = model.Email,
                    RoleId = 3,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    CreatedAt = DateTime.Now,
                    Status = (int)Enums.GeneralStatus.Deactivated
                };

                int customerId = _customerService.Create(customer, model.Phone).Id;
                if(customerId == 0){
                    return Ok(new {
                        Code = 500,
                        Message = "Registration failed"
                    });
                }
                return Ok(new {
                        Code = 200,
                        Message = "Successfully registered"
                    });
            } catch(Exception ex) {
                return BadRequest(new { Message = ex.Message });
            }
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Authenticate([FromBody] CustomerSignInModel model){
            try{
                if (string.IsNullOrEmpty(model.Phone) || string.IsNullOrEmpty(model.Password))
                    throw new AppException("Password is required");
                var customer = _customerService.Authenticate(model.Phone, model.Password);
                if (customer == null)
                    return BadRequest(new { message = "Phone or password is incorrect" });
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, customer.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                // return basic user info and authentication token
                return Ok(new
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Phone = customer.Phone,
                    Email = customer.Email,
                    Avatar = customer.Avatar,
                    Token = tokenString
                });
            }catch(Exception ex){
                return BadRequest(new { Message = ex.Message });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
