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

        [HttpPost("AddEquipment")]
        public async Task<IActionResult> Add(EquipmentDTO equipmentDTO)
        {
            _equipmentService.Add(equipmentDTO);
            _equipmentService.SaveChanges();
            return Ok(new
            {
                status = 200
            });
        }
    }
}
