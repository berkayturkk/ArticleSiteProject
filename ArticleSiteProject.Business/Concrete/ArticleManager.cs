using ArticleSiteProject.Business.Abstract;
using ArticleSiteProject.DataAccess.Abstract;
using ArticleSiteProject.DataAccess.Repository;
using ArticleSiteProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleSiteProject.Business.Concrete
{
    public class ArticleManager : IArticleService
    {
        private IArticleDAL _articleDAL;

        public ArticleManager()
        {
            _articleDAL = new ArticleRepository();
        }

        public Article CreateArticle(Article article)
        {
            return _articleDAL.CreateArticle(article);
        }

        public void DeleteArticle(int id)
        {
            _articleDAL.DeleteArticle(id);
        }

        public List<Article> GetAllArticles()
        {
            return _articleDAL.GetAllArticles();
        }

        public Article GetArticleById(int id)
        {
            if (id > 0)
            {
                return _articleDAL.GetArticleById(id);
            }

            throw new Exception("ID 1'den küçük olamaz !");
        }

        public Article UpdateArticle(Article article)
        {
            return _articleDAL.UpdateArticle(article);
        }
    }
}
