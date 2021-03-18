using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using MovieTheater.Models;

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
  }
}