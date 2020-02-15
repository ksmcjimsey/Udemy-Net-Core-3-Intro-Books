using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        [BindProperty]
        public Book EditBook { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }


        // Get will get the ID and load the data into the form
        public async Task OnGet(int id)
        {
            // go to database and find the book with an id of id.
            EditBook = await _db.Book.FindAsync(id);
        }

        // Put will update the values in the DB.
    }
}