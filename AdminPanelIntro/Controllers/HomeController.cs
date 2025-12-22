using AdminPanelIntro.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanelIntro.Controllers;

public class HomeController : Controller
{
    private readonly ProniaDbContext _context;

    public HomeController(ProniaDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var shippingItems = _context.ShippingItems.ToList();
        return View(shippingItems);
    }
}
