using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MovieTheater.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieTheater.Controllers
{
  public class CustomersController : Controller
  {
    private readonly MovieTheaterContext _db;
    public CustomersController(MovieTheaterContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      return View(_db.Customers.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }
  }
}