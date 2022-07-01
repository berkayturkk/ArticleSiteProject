using ArticleSiteProject.DataAccess.Concrete.Context;
using ArticleSiteProject.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ArticleSiteProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleApiController : ControllerBase
    {

        // Makaleleri listeleme metodu

        [HttpGet]
        public IActionResult ArticleList()
        {
            using var sqlDbContext = new SqlDbContext();
            var articles = sqlDbContext.Articles.ToList();
            return Ok(articles);
        }

        // Makale ekleme metodu

        [HttpPost]
        public IActionResult ArticleAdd(Article article)
        {
            using var sqlDbContext = new SqlDbContext();
            sqlDbContext.Add(article);
            sqlDbContext.SaveChanges();
            return Ok();
        }

        // Id'ye göre makale getirme metodu
        [HttpGet("{id}")]
        public IActionResult ArticleGet(int id)
        {
            using var sqlDbContext = new SqlDbContext();
            var article = sqlDbContext.Articles.Find(id);
            if (article == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(article);
            }
        }

        // Id'ye göre makale silme metodu

        [HttpDelete("{id}")]
        public IActionResult ArticleDelete(int id)
        {
            using var sqlDbContext = new SqlDbContext();
            var articleDel = sqlDbContext.Articles.Find(id);
            if (articleDel == null)
            {
                return NotFound();
            }
            else
            {
                sqlDbContext.Remove(articleDel);
                sqlDbContext.SaveChanges();
                return Ok();
            }
        }

        // Makale güncelleme metodu

        [HttpPut]
        public IActionResult ArticleUpdate(Article article)
        {
            using var sqlDbContext = new SqlDbContext();
            var articleUp = sqlDbContext.Find<Article>(article.ArticleID);
            if (articleUp == null)
            {
                return NotFound();
            }
            else
            {
                articleUp.ArticleTitle = article.ArticleTitle;
                articleUp.ArticleContent = article.ArticleContent;
                articleUp.ArticleCategoryName = article.ArticleCategoryName;
                articleUp.ArticleWriterName = article.ArticleWriterName;
                articleUp.ArticleUpdateDate = System.DateTime.Now;
                sqlDbContext.Update(articleUp);
                sqlDbContext.SaveChanges();
                return Ok(articleUp);
            }
        }

    }
}
