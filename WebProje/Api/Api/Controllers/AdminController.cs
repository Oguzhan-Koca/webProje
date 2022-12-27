using Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebProje.Entities;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
       
        public readonly DataBaseWebContext _context;
        public AdminController(DataBaseWebContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAdmin()
        {
            return Ok(_context.Admin.ToList());
        }

       
//        [HttpPut("{id}")]
//        public IActionResult UpdateAdmin(int id, Admin admin)
//        {
//            var updateUrun=_context.Admin.FirstOrDefault(I=>I.AdminId == id);
//            updateUrun.Baslik = admin.Baslik;
//            _context.SaveChanges();
//                return NoContent(); 
//        }

//        [HttpDelete("{id}")]
//        public IActionResult DeleteAdmin(int id)
//        {
//            var deletedUrun = _context.Urun.FirstOrDefault(I => I.AdminId == id);

//            _context.Remove(deletedUrun);
//            _context.SaveChanges();
//            return NoContent();
//        }

//        [HttpPost]
//        public IActionResult AddAdmin(Admin urun) {
        
//            _context.Add(urun);
//            _context.SaveChanges();
//            return Created("", urun);
//        }
    }
}
