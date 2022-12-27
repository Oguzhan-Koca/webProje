﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebProje.Models.Entities;

namespace WebProje.Controllers
{
    public class UrunController : Controller
    {
        public IActionResult Index()
        {

            HttpClient client = new HttpClient();
            var respondeMessage = client.GetAsync("https://localhost:44308/api/Uruns").Result;
            List<Urun> urun = null;
            if (respondeMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                urun = JsonConvert.DeserializeObject<List<Urun>>(respondeMessage.Content.ReadAsStringAsync().Result);
            }

            return View(urun);
        }
        //public IActionResult Login()
        //{
        //    return View();
        //}
        public IActionResult Ekle()
        {
            return View(new Urun());
        }

        [HttpPost]
        public IActionResult Ekle(Urun urun)
        {

            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(urun), Encoding.UTF8,
                "application/json");

            var responseMessage = httpClient.PostAsync("https://localhost:44308/api/Uruns", content).Result;
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Ekleme işlemi başarısız");
            return View();
        }
        //[HttpPost]
        //public IActionResult GetUrunById(Urun urun)
        //{
        //    string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
        //    string uzanti = Path.GetExtension(Request.Files[0].FileName);
        //    string yol = "~/Image/" + dosyaAdi + uzanti;
        //    Files[0].SaveAs(Server.MapPath(yol));
        //    urun.ResimURL = "/Image/" + dosyaAdi + uzanti;
        //    return Ok(_context.Urun.ToList());
        //}
        public IActionResult Guncelle(int id)
        {
            HttpClient httpClient = new HttpClient();
            var responseMessage = httpClient.GetAsync($"https://localhost:44308/api/Uruns/{id}").Result;
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var urun = JsonConvert.DeserializeObject<Urun>(responseMessage.Content.ReadAsStringAsync().Result);
                return View(urun);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Guncelle(Urun urun)
        {
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(urun), Encoding.UTF8,
                "application/json");
            var responseMessage = httpClient.PutAsync($"https://localhost:44308/api/Uruns/{urun.UrunId}", content).Result;
            return RedirectToAction("Index");

        }
        public IActionResult Sil(int id)
        {
            HttpClient httpClient = new HttpClient();
            var responseMessage = httpClient.DeleteAsync($"https://localhost:44308/api/Uruns/{id}").Result;
            return RedirectToAction("Index");
        }


    }
}

