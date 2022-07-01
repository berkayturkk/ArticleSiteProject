using ArticleSiteProject.DataAccess.Abstract;
using ArticleSiteProject.DataAccess.Concrete.Context;
using ArticleSiteProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleSiteProject.DataAccess.Repository
{
    public class ArticleRepository : IArticleDAL
    {
        public Article CreateArticle(Article article)
        {
            using (var sqlDbContext = new SqlDbContext())
            {
                sqlDbContext.Articles.Add(article);
                sqlDbContext.SaveChanges();
                return article;
            }
        }

        public void DeleteArticle(int id)
        {
            using (var sqlDbContext = new SqlDbContext())
            {
                var deleteArticle = GetArticleById(id);
                sqlDbContext.Articles.Remove(deleteArticle);
                sqlDbContext.SaveChanges();
            }
        }

        public List<Article> GetAllArticles()
        {
            using (var sqlDbContext = new SqlDbContext())
            {
                return sqlDbContext.Articles.ToList();
            }
        }

        public Article GetArticleByCategoryName(string title)
        {
            using (var sqlDbContext = new SqlDbContext())
            {
                return sqlDbContext.Articles.Find(title);
            }
        }

        public Article GetArticleById(int id)
        {
            using (var sqlDbContext = new SqlDbContext())
            {
                return sqlDbContext.Articles.Find(id);
            }
        }

        public Article UpdateArticle(Article article)
        {
            using (var sqlDbContext = new SqlDbContext())
            {
                sqlDbContext.Articles.Update(article);
                sqlDbContext.SaveChanges();
                return article;
            }
        }
    }
}
