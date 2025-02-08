using Domain.Entity;
using Domain.RepositoryInterface;
using Infrasturcture.DataDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrasturcture.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BlogRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }



       public void Add(Blog blog)
        {
            _dbContext.Blogs.Add(blog);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var blog = _dbContext.Blogs.Find(id);
            if (blog != null)
            {
                _dbContext.Blogs.Remove(blog);
                _dbContext.SaveChanges();
            }

        }

        public IEnumerable<Blog> GetAll()
        {
           return _dbContext.Blogs.ToList();
        }

        public Blog GetById(int id)
        {
            var blog = _dbContext.Blogs.Find(id);
            if (blog == null)
            {
                throw new Exception($"Blog with ID {id} not found");
            }
            return blog;
        }

        public void Update(Blog blog)
        {
            _dbContext.Blogs.Update(blog);
            _dbContext.SaveChanges();
        }
    }
}
