using Azure.Core;
using HotelUltraGroup.Core.Application.Common;
using HotelUltraGroup.Core.Application.Common.Interfaces;
using HotelUltraGroup.Core.Application.DTOs;
using HotelUltraGroup.Core.Application.Interfaces.Services;
using HotelUltraGroup.Core.Application.Services;
using HotelUltraGroup.Core.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace HotelUltraGroup.Presentation.API.Controllers
{
    [Produces("application/json")]
    [Route("api/HotelUltraGroup/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _service;        

        public HotelController( IHotelService service)
        {
            _service = service;
        }


        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResultAPI<IEnumerable<ListHotelDTO>>))]
        public async Task<IActionResult> GetHotelsAsync()
        {
            try
            {
                var user = HttpContext.User;
                var idUser = int.Parse(user.FindFirst("Id").Value);
                var response = await _service.GetHotelsAsync(idUser);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
          
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResultAPI<string>))]
        public async Task<IActionResult> CreateHotel(CreateHotelDTO createHotelDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            try
            {
                var user = HttpContext.User;
                var idUser = int.Parse(user.FindFirst("Id").Value);
                var response = await _service.CreateHotelAsync(idUser, createHotelDTO);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResultAPI<string>))]
        public async Task<IActionResult> UpdateHotel(UpdateHotelDTO updateHotelDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var user = HttpContext.User;
                var idUser = int.Parse(user.FindFirst("Id").Value);
                var response = await _service.UpdateHotelAsync(idUser, updateHotelDTO);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResultAPI<string>))]
        public async Task<IActionResult> UpdateStatusHotelAsync(UpdateStatusHotelDTO updateStatusHotelDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var user = HttpContext.User;
                var idUser = int.Parse(user.FindFirst("Id").Value);
                var response = await _service.UpdateStatusHotelAsync(idUser, updateStatusHotelDTO);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

   
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResultAPI<IEnumerable<ListReservationDTO>>))]
        public async Task<IActionResult> GetReservationsByHotel(int idHotel)
        {
            try
            {
                var user = HttpContext.User;
                var idUser = int.Parse(user.FindFirst("Id").Value);
                var response = await _service.GetReservationsByHotel(idUser, idHotel);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

    
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResultAPI<IEnumerable<ListReservationDetailDTO>>))]
        public async Task<IActionResult> GetReservationDetail(int idHotel, int idReservation)
        {
            try
            {
                var user = HttpContext.User;
                var idUser = int.Parse(user.FindFirst("Id").Value);
                var response = await _service.GetReservationDetail(idUser, idHotel, idReservation);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }



    }
}
