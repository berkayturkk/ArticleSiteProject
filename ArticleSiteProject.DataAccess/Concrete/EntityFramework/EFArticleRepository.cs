using ArticleSiteProject.DataAccess.Abstract;
using ArticleSiteProject.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleSiteProject.DataAccess.Concrete.EntityFramework
{
    public class EFArticleRepository : ArticleRepository, IArticleDAL
    {
    }
}
