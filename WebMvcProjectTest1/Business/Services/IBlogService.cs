using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IBlogService
    {
        IEnumerable<Blog> GetAllBlog();
        Blog GetBlogById(int id);
        void AddBlog(Blog blog);
        void UpdateBlog(Blog blog);
        void DeleteBlog (int id);
    }
}
