using Azure.Core;
using HotelUltraGroup.Core.Application.Common;
using HotelUltraGroup.Core.Application.Common.Interfaces;
using HotelUltraGroup.Core.Application.DTOs;
using HotelUltraGroup.Core.Application.Interfaces.Services;
using HotelUltraGroup.Core.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace HotelUltraGroup.Presentation.API.Controllers
{
    [Produces("application/json")]
    [Route("api/HotelUltraGroup/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _service;        

        public RoomController(IRoomService service)
        {
            _service = service;
        }
     

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResultAPI<IEnumerable<ListRoomWithRoomTypeDto>>))]
        public async Task<IActionResult> GetRoomsWithRoomTypeAsync( int idHotel)
        {
            try
            {
                var user = HttpContext.User;
                var idUser = int.Parse(user.FindFirst("Id").Value);
                var response = await _service.GetRoomsWithRoomTypeAsync(idUser,idHotel);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResultAPI<string>))]
        public async Task<IActionResult> CreateRoomAsync(CreateRoomDTO createRoomDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            try
            {
                var user = HttpContext.User;
                var idUser = int.Parse(user.FindFirst("Id").Value);
                var response = await _service.CreateRoomAsync(idUser, createRoomDTO);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResultAPI<string>))]
        public async Task<IActionResult> UpdateRoomAsync(UpdateRoomDTO updateRoomDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var user = HttpContext.User;
                var idUser = int.Parse(user.FindFirst("Id").Value);
                var response = await _service.UpdateRoomAsync(idUser, updateRoomDTO);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResultAPI<string>))]
        public async Task<IActionResult> UpdateRoomStatusAsync(UpdateStatusRoomDTO updateStatusRoomDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var user = HttpContext.User;
                var idUser = int.Parse(user.FindFirst("Id").Value);
                var response = await _service.UpdateRoomStatusAsync(idUser,updateStatusRoomDTO);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }



        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResultAPI<string>))]
        public async Task<IActionResult> CreateTaxAsync(CreateTaxDTO createTaxDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var user = HttpContext.User;
                var idUser = int.Parse(user.FindFirst("Id").Value);
                var response = await _service.CreateTaxAsync(idUser,createTaxDTO);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResultAPI<string>))]
        public async Task<IActionResult> UpdateTaxAsync(UpdateTaxDTO updateTaxDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var user = HttpContext.User;
                var idUser = int.Parse(user.FindFirst("Id").Value);
                var response = await _service.UpdateTaxAsync(idUser, updateTaxDTO);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }



        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResultAPI<string>))]
        public async Task<IActionResult> AssignTaxToRoomAsync(RoomTaxAssignmentDTO roomTaxAssignmentDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var user = HttpContext.User;
                var idUser = int.Parse(user.FindFirst("Id").Value);
                var response = await _service.AssignTaxToRoomAsync(idUser, roomTaxAssignmentDTO);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResultAPI<string>))]
        public async Task<IActionResult> RemoveTaxFromRoomAsync(RoomTaxAssignmentDTO roomTaxAssignmentDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var user = HttpContext.User;
                var idUser = int.Parse(user.FindFirst("Id").Value);
                var response = await _service.RemoveTaxFromRoomAsync(idUser, roomTaxAssignmentDTO);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IResultAPI<IEnumerable<ListTaxDTO>>))]
        public async Task<IActionResult> GetHotelTaxesAsync(int idHotel)
        {
            try
            {
                var user = HttpContext.User;
                var idUser = int.Parse(user.FindFirst("Id").Value);
                var response = await _service.GetHotelTaxesAsync(idUser, idHotel);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }
    }
}
