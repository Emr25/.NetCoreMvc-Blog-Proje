using Domain.Entity;
using Domain.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }



        public void AddBlog(Blog blog)
        {
            _blogRepository.Add(blog);
        }

        public void DeleteBlog(int id)
        {
            _blogRepository.Delete(id);
        }

        public IEnumerable<Blog> GetAllBlog()
        {
            return _blogRepository.GetAll();
        }

        public Blog GetBlogById(int id)
        {
           return _blogRepository.GetById(id);
        }

        public void UpdateBlog(Blog blog)
        {
            _blogRepository.Update(blog);
        }
    }
}
