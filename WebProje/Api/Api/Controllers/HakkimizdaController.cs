using Api.Entities;
using Microsoft.AspNetCore.Mvc;
using WebProje.Entities;

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
            return Ok(_context.Hakkimizda.FirstOrDefault(A => A.HakkimizdaId == id));
        }
        [HttpPost]
        public IActionResult AddUrun(Hakkimizda hakkimizda)
        {

            _context.Add(hakkimizda);
            _context.SaveChanges();
            return Created("", hakkimizda);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUrun(int id)
        {
            var deletedHakkimizda = _context.Hakkimizda.FirstOrDefault(A => A.HakkimizdaId == id);

            _context.Remove(deletedHakkimizda);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateUrun(int id, Hakkimizda hakkimizda)
        {
            var updateHakkimizda = _context.Hakkimizda.FirstOrDefault(A => A. HakkimizdaId == id);
            updateHakkimizda.HakkimizdaId = hakkimizda.HakkimizdaId;
            updateHakkimizda.Aciklama = hakkimizda.Aciklama;
           
            _context.SaveChanges();
            return NoContent();
        }
    }
}
