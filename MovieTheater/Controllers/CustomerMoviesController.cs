using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using MovieTheater.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MovieTheater.Controllers
{
  public class CustomerMoviesController : Controller
  {
    private readonly MovieTheaterContext _db;
    public CustomerMoviesController(MovieTheaterContext db)
    {
      _db = db;
    }

    public ActionResult Create()
    {
      ViewBag.Customers = new SelectList(_db.Customers, "CustomerId", "CustomerName");
      ViewBag.Movies = new SelectList(_db.Movies, "MovieId", "Name");
      return View();
    }
    [HttpPost]
    public ActionResult Create(Customer customer, Movie movie)
    {
      if (movie.MovieId != 0 && customer.CustomerId !=0)
      {
        _db.CustomerMovie.Add(new CustomerMovie()
        {
          MovieId = movie.MovieId, CustomerId = customer.CustomerId
        });
        _db.SaveChanges();
      }
        return RedirectToAction("Index", "Home");
    }
  }
}