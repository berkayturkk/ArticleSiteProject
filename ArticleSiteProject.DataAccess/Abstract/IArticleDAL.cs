using ArticleSiteProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleSiteProject.DataAccess.Abstract
{
    public interface IArticleDAL
    {
        List<Article> GetAllArticles();
        Article GetArticleById(int id);
        Article CreateArticle(Article article);
        Article UpdateArticle(Article article);
        void DeleteArticle(int id);
    }
}
