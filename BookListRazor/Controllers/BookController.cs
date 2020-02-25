using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookListRazor.Controllers
{
    // Creating an API that can be used to get data from the Book db
    [Route("api/Book")]     // Need to route to the API controller
    [ApiController]
    public class BookController : Controller
    {

        private readonly ApplicationDbContext _db;


        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            // data is a list of book that is then turned into JSON format.
            return Json(new { data = _db.Book.ToList() });
        }
    }
}