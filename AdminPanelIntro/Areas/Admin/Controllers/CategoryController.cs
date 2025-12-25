using AdminPanelIntro.Contexts;
using AdminPanelIntro.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanelIntro.Areas.Admin.Controllers;
[Area("Admin")]
[AutoValidateAntiforgeryToken]
public class CategoryController : Controller
{
    private readonly ProniaDbContext _context;

    public CategoryController(ProniaDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var categories = _context.Categories.ToList();
        return View(categories);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Category category)
    {
        if (!ModelState.IsValid)
        {
            return View(category);
        }

        _context.Categories.Add(category);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var category = _context.Categories.Find(id);

        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    [HttpPost]
    public IActionResult Update(Category category)
    {
        if (!ModelState.IsValid)
        {
            return View(category);
        }

        var existCategory = _context.Categories.Find(category.Id);

        if (existCategory == null)
        {
            return NotFound();
        }

        existCategory.Name = category.Name;
        _context.Categories.Update(existCategory);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        var category = _context.Categories.Find(id);

        if (category == null)
        {
            return NotFound();
        }

        _context.Categories.Remove(category);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
