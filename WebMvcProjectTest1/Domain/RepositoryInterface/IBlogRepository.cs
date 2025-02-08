using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterface
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> GetAll();
        Blog GetById(int id);
        void Add(Blog blog);
        void Update(Blog blog);
        void Delete(int id);

    }
}
