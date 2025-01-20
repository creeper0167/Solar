using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solar.Application;
using Solar.Application.DTOs;

namespace Solar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : Controller
    {
        private readonly IEquipmentService _equipmentService;
        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }
        [Authorize]
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _equipmentService.GetAll();
            return Ok(new
            {
                result = result,
                status = 200
            });
        }
        [Authorize]
        [HttpPost("AddEquipment")]
        public async Task<IActionResult> Add(EquipmentDTO equipmentDTO)
        {
            equipmentDTO.UserId = Int32.Parse(HttpContext.User.FindFirst("userId")?.Value);
            _equipmentService.Add(equipmentDTO);
            _equipmentService.SaveChanges();
            return Ok(new
            {
                status = 200
            });
        }
    }
}
