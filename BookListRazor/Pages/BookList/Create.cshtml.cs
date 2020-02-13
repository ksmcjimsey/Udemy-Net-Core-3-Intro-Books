using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor
{
    public class CreateModel : PageModel
    {
        // This page will open up a blank form and when submitted will call the OnPost() method to 
        // add the data to the DB
        //
        // 1. First step is to get the db context.  
        //    In pipeline so we can use dependency injection
        private readonly ApplicationDbContext _db;

        // 2. Create a model to hold the return from the user
        public Book Book { get; set; }

        // 3. Create a constructor (ctro tab tab)
        //    We get the ApplicationDbContext through depencency injection.
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }


        public void OnGet()
        {

        }


        // Save the submittion to the DB
        public void OnPost()
        {

        }
    }
}