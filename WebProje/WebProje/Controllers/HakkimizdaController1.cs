using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebProje.Models.Entities;


namespace WebProje.Controllers
{
    public class Hakkimizda : Controller
    {

        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            var responseMessage = client.GetAsync("https://localhost:44308/api/Hakkimizda").Result;
            List<Hakkimizda> hakkimizda = null;
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                hakkimizda = JsonConvert.DeserializeObject<List<Hakkimizda>>(responseMessage.Content.ReadAsStringAsync().Result);
            }

            return View(hakkimizda);

        }
        public IActionResult Ekle()
        {
            return View(new Hakkimizda());
        }

        [HttpPost]
        public IActionResult Ekle(Hakkimizda hakkimizda)
        {

            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(hakkimizda), Encoding.UTF8,
                "application/json");

            var responseMessage = httpClient.PostAsync("https://localhost:44308/api/Hakkimizda", content).Result;
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Ekleme işlemi başarısız");
            return View();
        }

        public IActionResult Guncelle(int id)
        {
            HttpClient httpClient = new HttpClient();
            var responseMessage = httpClient.GetAsync($"https://localhost:44308/api/Hakkimizda/{id}").Result;
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var hakkimizda = JsonConvert.DeserializeObject<Hakkimizda>(responseMessage.Content.ReadAsStringAsync().Result);
                return View(hakkimizda);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Sil(int id)
        {
            HttpClient httpClient = new HttpClient();
            var responseMessage = httpClient.DeleteAsync($"https://localhost:44308/api/Hakkimizda/{id}").Result;
            return RedirectToAction("Index");
        }


    }
}

