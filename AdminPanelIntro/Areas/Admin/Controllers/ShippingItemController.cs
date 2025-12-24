using AdminPanelIntro.Contexts;
using AdminPanelIntro.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanelIntro.Areas.Admin.Controllers;
[Area("Admin")]
[AutoValidateAntiforgeryToken]
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

    [HttpGet]
    public IActionResult Update(int id)
    {
        var shippingItem=_context.ShippingItems.Find(id);
        if (shippingItem == null)
        {
            return NotFound();
        }
        return View(shippingItem);
    }

    [HttpPost]
    public IActionResult Update(ShippingItem shippingItem)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        var existShippingItem= _context.ShippingItems.Find(shippingItem.Id);
        if (existShippingItem == null)
        {
            return NotFound();
        }

        existShippingItem.Name = shippingItem.Name;
        existShippingItem.Description = shippingItem.Description;
        existShippingItem.ImageUrl= shippingItem.ImageUrl;

        _context.ShippingItems.Update(existShippingItem);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
