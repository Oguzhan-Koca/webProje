using Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebProje.Entities;


namespace Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UrunsController : ControllerBase
    {
        private readonly DataBaseWebContext _context;
        public UrunsController(DataBaseWebContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetUrun()
        {
            return Ok(_context.Urun.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetUrunById(int id)
        {
            return Ok(_context.Urun.FirstOrDefault(I => I.UrunId == id));
        }
        


        [HttpPut("{id}")]
        public IActionResult UpdateUrun(int id, Urun urun)
        {
            var updateUrun = _context.Urun.FirstOrDefault(I => I.UrunId == id);
            updateUrun.Baslik = urun.Baslik;
            updateUrun.Aciklama= urun.Aciklama;
            updateUrun.ResimURL = urun.ResimURL;
            updateUrun.UrunId = urun.UrunId;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUrun(int id)
        {
            var deletedUrun = _context.Urun.FirstOrDefault(I => I.UrunId == id);

            _context.Remove(deletedUrun);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPost]
        public IActionResult AddUrun(Urun urun)
        {

            _context.Add(urun);
            _context.SaveChanges();
            return Created("", urun);
        }

    }
}
