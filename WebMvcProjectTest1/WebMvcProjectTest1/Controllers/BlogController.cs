using Business.Services;
using Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace WebMvcProjectTest1.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IWebHostEnvironment _webHostEnvironment;



        public BlogController(IBlogService service, IWebHostEnvironment webHostEnvironment)
        {
            _blogService = service;
            _webHostEnvironment = webHostEnvironment;
        }



        public IActionResult Index()
        {
            var blog = _blogService.GetAllBlog();
            return View(blog);
        }

        public IActionResult Details(int id)
        {
            var blog = _blogService.GetBlogById(id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        [Authorize]
        public IActionResult Create()
        {
          return View();
        }

        [HttpPost]
        public  IActionResult CreateAsync (Blog blog)
        {
           
            _blogService.AddBlog(blog);
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Edit (int id)
        {
            var blog = _blogService.GetBlogById(id);
            if(blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        [HttpPost]
        public IActionResult Edit (Blog blog)
        {
            _blogService.UpdateBlog(blog);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var blog = _blogService.GetBlogById(id);
            if( blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var blog = _blogService.GetBlogById(id);
            if (blog == null)
            {
                return NotFound();
            }

            _blogService.DeleteBlog(id);
            return RedirectToAction("Index");
        }

    }
}
