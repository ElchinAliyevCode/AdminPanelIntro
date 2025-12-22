using AdminPanelIntro.Contexts;
using AdminPanelIntro.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanelIntro.Areas.Admin.Controllers;
[Area("Admin")]
public class ShippingItemController : Controller
{
    private readonly ProniaDbContext _context;

    public ShippingItemController(ProniaDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var shippingItems= _context.ShippingItems.ToList();
        return View(shippingItems);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(ShippingItem shippingItem)
    {
        if (!ModelState.IsValid)
        {
            return View(shippingItem);
        }

        _context.ShippingItems.Add(shippingItem);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        var item = _context.ShippingItems.Find(id);
        if (item == null)
        {
            return NotFound();
        }
        _context.ShippingItems.Remove(item);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
}
