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
        // When we redirect to a new page after handleing the form post
        // return we need to give Task a tyep of IActionResult
        public async Task <IActionResult> OnPost ()
        {
            // Make sure the Model came back valid
            if (ModelState.IsValid)
            {
                // Get the book from the DB.  The ID came back in the bind Editbook.Id property.
                // Must have the ID in the form even if hidden or it will not be set and this
                // line will give an error.
                // Error: NullReferenceException: Object reference not set to an instance of an object.
                var BookFromDb = await _db.Book.FindAsync(EditBook.Id);

                // Set our new values from the form into the record that we got from the DB.
                // From data --> Bound object --> DB record object
                BookFromDb.Name = EditBook.Name;
                BookFromDb.ISBN = EditBook.ISBN;
                BookFromDb.Author = EditBook.Author;

                await _db.SaveChangesAsync();   // Saves the changes to the DB

                return RedirectToPage("Index");
            }

            // If model state is bad then redirect back to the same edit page
            return RedirectToPage();

        }
    }
}