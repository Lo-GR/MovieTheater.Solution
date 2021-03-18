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
  }
}