using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebProje.Models.Entities;

namespace WebProje.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {

            HttpClient client = new HttpClient();
            var respondeMessage = client.GetAsync("https://localhost:44308/api/Admin").Result;
            List<Admin> admin = null;
            if (respondeMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                admin = JsonConvert.DeserializeObject<List<Admin>>(respondeMessage.Content.ReadAsStringAsync().Result);
            }

            return View(admin);
        }
    
     public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Admin admin)
        {
            HttpClient client = new HttpClient();
            var respondeMessage = client.GetAsync("https://localhost:44308/api/Admin").Result;
            if (respondeMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
               
                var adminY = JsonConvert.DeserializeObject<List<Admin>>(respondeMessage.Content.ReadAsStringAsync().Result);
                
            }
            return View();
        }   
    }
    
}


