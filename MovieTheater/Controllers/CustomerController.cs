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

    [HttpPost]
    public ActionResult Create(Customer customer)
    {
      _db.Customers.Add(customer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Customer thisCustomer = _db.Customers
        .Include( customer=>customer.JoinEntities)
        .ThenInclude(join=>join.Movie)
        .FirstOrDefault(customer=>customer.CustomerId == id);
      return View(thisCustomer);
    }

    public ActionResult Delete(int id)
    {
      Customer thisCustomer = _db.Customers.FirstOrDefault(customer => customer.CustomerId == id);
      return View(thisCustomer);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Customer thisCustomer = _db.Customers.FirstOrDefault(customer => customer.CustomerId == id);
      _db.Customers.Remove(thisCustomer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Edit(int id)
    {
      Customer model = _db.Customers.FirstOrDefault(customer => customer.CustomerId == id);
      return View(model);
    }
    [HttpPost]
    public ActionResult Edit(Customer customer)
    {
      _db.Entry(customer).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}