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

    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _service;        

        public ReservationController(IReservationService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResultAPI<IEnumerable<ListGenderDTO>>))]
        public async Task<IActionResult> GetGenderListAsync()
        {
            try
            {
                var response = await _service.GetGenderListAsync();
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResultAPI<IEnumerable<ListDocumentTypeDTO>>))]
        public async Task<IActionResult> GetDocumentTypeListAsync()
        {
            try
            {
                var response = await _service.GetDocumentTypeListAsync();
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResultAPI<IEnumerable<ListCityDTO>>))]
        public async Task<IActionResult> GetCityListAsync()
        {
            try
            {
                var response = await _service.GetCityListAsync();
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResultAPI<IEnumerable<ListAvailableHotelsDTO>>))]
        public async Task<IActionResult> GetAvailableHotelsAsync(DateTime checkInDate, DateTime checkOutDate, int numberOfPeople, int idCity)
        {
            try
            {
                var response = await _service.GetAvailableHotelsAsync( checkInDate, checkOutDate, numberOfPeople, idCity);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResultAPI<IEnumerable<ListAvailableHotelRoomsDTO>>))]
        public async Task<IActionResult> GetAvailableHotelRoomsAsync(int idHotel, DateTime checkInDate, DateTime checkOutDate, int numberOfPeople)
        {
            try
            {
                var response = await _service.GetAvailableHotelRoomsAsync(idHotel, checkInDate, checkOutDate, numberOfPeople);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

       

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResultAPI<string>))]
        public async Task<IActionResult> CreateReservationAsync(CreateReservationDTO createReservationDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            try
            {
                var response = await _service.CreateReservationAsync(createReservationDTO);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResultAPI<string>))]
        public async Task<IActionResult> RegisterGuestAsync(CreateGuestDTO createGuestDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var response = await _service.RegisterGuestAsync(createGuestDTO);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }



    }
}
