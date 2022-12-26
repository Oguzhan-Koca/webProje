using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebProje.Models.Entities;

namespace WebProje.Controllers
{
    public class AdminController : Controller
    {
        public  IActionResult Index()
        {

            HttpClient client= new HttpClient();
            var respondeMessage = client.GetAsync("https://localhost:44308/api/Uruns").Result;
            List<Urun> urun = null;
            if (respondeMessage.StatusCode==System.Net.HttpStatusCode.OK)
            {
              urun = JsonConvert.DeserializeObject<List<Urun>> ( respondeMessage.Content.ReadAsStringAsync().Result);
            }

            return View(urun);
        }
        public IActionResult Login()
        {
            return View();
        }
    }

}
