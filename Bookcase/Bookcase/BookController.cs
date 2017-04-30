using Bookcase.Models;
using Bookcase.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bookcase
{
    public class BookController : Controller
    {
        private readonly IService<Book> _bookService;

        public BookController(IService<Book> bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            return View(_bookService.GetItemsAsync());
        }
    }
}
