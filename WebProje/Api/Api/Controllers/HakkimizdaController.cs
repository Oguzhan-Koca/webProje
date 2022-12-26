using Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HakkimizdaController : ControllerBase
    {
        private readonly DataBaseWebContext _context;
        public HakkimizdaController(DataBaseWebContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetHakkimizda()
        {
            return Ok(_context.Hakkimizda.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetGetHakkimizdaById(int id)
        {
            return Ok(_context.Hakkimizda.FirstOrDefault(I => I.HakkimizdaId == id));
        }
    }
}
