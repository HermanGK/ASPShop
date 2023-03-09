using ASPShop.Data;
using ASPShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPShop.Controllers;

public class CapController : Controller
{
    private readonly AppDbContext _context;

    public CapController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        List<Main> items = _context.items.Where(el => el.Class == "cap").ToList();
        return View(items);
    }
}
