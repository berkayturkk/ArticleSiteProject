using ArticleSiteProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleSiteProject.Entities.Concrete
{
    public class Article : IEntity
    {
        [Key]
        public int ArticleID { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleContent { get; set; }
        public string? ArticleImage { get; set; }
        public string ArticleCategoryName { get; set; }
        public string ArticleWriterName { get; set; }
        public DateTime ArticleCreateDate { get; set; }
        public DateTime? ArticleUpdateDate { get; set; }
    }
}
