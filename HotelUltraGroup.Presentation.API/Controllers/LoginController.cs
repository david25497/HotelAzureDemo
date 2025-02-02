using HotelUltraGroup.Core.Application.Common;
using HotelUltraGroup.Core.Application.Common.Interfaces;
using HotelUltraGroup.Core.Application.DTOs;
using HotelUltraGroup.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace HotelUltraGroup.Presentation.API.Controllers
{
    [Produces("application/json")]
    [Route("api/HotelUltraGroup/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _service;
        IConfiguration _Configuration;
    

        public LoginController(IConfiguration Config, IUserService service)
        {
            this._Configuration = Config;
            _service = service;
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResultAPI<string>))]
        public async Task<IActionResult> SetInsertarUsuario(CreateUserDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
               var response= await _service.CreateNewUserAsync(request);
               return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResultAPI<string>))]
        public async Task<IActionResult> Login(LoginDTO _loginDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TokenConfigDTO _TokenConfigDTO = new TokenConfigDTO();
            _TokenConfigDTO.key = _Configuration["AuthSettings:key"];
            _TokenConfigDTO.durationInMinutes = _Configuration["AuthSettings:DurationInMinutes"];
            _TokenConfigDTO.issuer = _Configuration["AuthSettings:Issuer"];
            _TokenConfigDTO.audience = _Configuration["AuthSettings:Audience"];
            var response = await _service.LoginAsync(_loginDTO, _TokenConfigDTO);

            return Ok(response);
        }

    }
}
