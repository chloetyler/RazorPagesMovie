using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
{
    private readonly RazorPagesMovie.Models.RazorPagesMovieContext _context;

    public IndexModel(RazorPagesMovie.Models.RazorPagesMovieContext context)
    {
        _context = context;
    }

    public IList<Movie> Movie { get; set; }
    [BindProperty(SupportsGet = true)]
    public string SearchString { get; set; }
    // Requires using Microsoft.AspNetCore.Mvc.Rendering;
    public SelectList Genres { get; set; }
    [BindProperty(SupportsGet = true)]
    public string MovieGenre { get; set; }



        // When a request is made for the page, the OnGetAsync 
        // method returns a list of movies to the Razor Page. 
        // OnGetAsync or OnGet is called on a Razor Page to initialize 
        // the state for the page. In this case, OnGetAsync gets 
            // a list of movies and displays them.

       public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            // IQueryable<string> genreQuery = from m in _context.Movie
            //                                 orderby m.Genre
            //                                 select m.Genre;

            var movies = from m in _context.Movie
                        select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            // if (!string.IsNullOrEmpty(MovieGenre))
            // {
            //     movies = movies.Where(x => x.Genre == MovieGenre);
            // }
            //Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }

    }
}

// Razor Pages are derived from PageModel. By convention, 
// the PageModel-derived class is called <PageName>Model. 
// The constructor uses dependency injection to add the 
// RazorPagesMovieContext to the page. All the scaffolded 
// pages follow this pattern. 
