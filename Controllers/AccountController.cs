using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreWebApi_v5.Data;
using NetCoreWebApi_v5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi_v5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;
        private readonly SignInManager<ApiUser> _signInManager;

        public AccountController(IMapper mapper, ILogger<AccountController> logger,
                                    UserManager<ApiUser> userManager,
                                    SignInManager<ApiUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Register([FromBody] UserDTO userDTO)
        {
            _logger.LogInformation($"Attempt to register {userDTO.EmailAddress} ");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = _mapper.Map<ApiUser>(userDTO);
                var result = await _userManager.CreateAsync(user);
                if (!result.Succeeded)
                {
                    return BadRequest($"User Registraion Has Failed");
                }
                return Ok($"New User created: {userDTO.EmailAddress}");
            }
            catch (Exception)
            {
                _logger.LogError(ex, $"Something went wrong in the  {nameof(Register)}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginUserDTO userDTO)
        {
            _logger.LogInformation($"Attempt to login {userDTO.EmailAddress} ");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _signInManager.PasswordSignInAsync(userDTO.EmailAddress, userDTO.Password, false, false);
                if (!result.Succeeded)
                {
                    return Unauthorized(userDTO);
                }

                return Ok($"Login Success : {userDTO.EmailAddress}");
            }
            catch (Exception)
            {
                _logger.LogError(ex, $"Something went wrong in the  {nameof(Register)}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
