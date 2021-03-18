using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieTheater.Controllers
{
  public class MoviesController : Controller
  {
    private readonly MovieTheaterContext _db;
    public MoviesController (MovieTheaterContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Movies.ToList());
    }
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Movie movie)
    {
      _db.Movies.Add(movie);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisMovie = _db.Movies
        .Include(movie => movie.JoinEntities)
        .ThenInclude(join => join.Customer)
        .FirstOrDefault(movie => movie.MovieId == id);
      return View(thisMovie);
    }

    public ActionResult Delete(int id)
    {
      var thisMovie = _db.Movies.FirstOrDefault(movie=>movie.MovieId == id);
      return View(thisMovie);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMovie = _db.Movies.FirstOrDefault(movie=>movie.MovieId == id);
      _db.Movies.Remove(thisMovie);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Edit(int id)
    {
      Movie model = _db.Movies.FirstOrDefault(movie => movie.MovieId == id);
      return View(model);
    }
    [HttpPost]
    public ActionResult Edit(Movie movie)
    {
      _db.Entry(movie).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}