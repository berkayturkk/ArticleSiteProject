using ArticleSiteProject.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ArticleSiteProject.UI.Controllers
{
    public class ArticleController : Controller
    {
        // Makaleleri listeleme ve arama metodu
        public async Task<IActionResult> Index(string key)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44369/api/ArticleApi");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Article>>(jsonString);
            var article = key == null ? values : values.Where(x => x.ArticleTitle == key).ToList();
            return View(article);
        }

        // Makale ekleme metodu

        [HttpGet]
        public IActionResult AddArticle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddArticle(Article article)
        {
            var httpClient = new HttpClient();
            var jsonArticle = JsonConvert.SerializeObject(article);
            StringContent content = new StringContent(jsonArticle, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:44369/api/ArticleApi", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(article);
        }

        // Makale Güncelleme Metodu

        [HttpGet]
        public async Task<IActionResult> EditArticle(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44369/api/ArticleApi/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonArticle = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Article>(jsonArticle);
                return View(values);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditArticle(Article article)
        {
            var httpClient = new HttpClient();
            var jsonArticle = JsonConvert.SerializeObject(article);
            var content = new StringContent(jsonArticle, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:44369/api/ArticleApi", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // Makale silme metodu
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:44369/api/ArticleApi/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();


        }
    }
}
