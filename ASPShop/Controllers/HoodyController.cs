using ASPShop.Data;
using ASPShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPShop.Controllers;

public class HoodyController : Controller
{
    private readonly AppDbContext _context;
    public HoodyController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        List<Main> items = _context.items.Where(el => el.Class == "hoody").ToList();
        return View(items);
    }
}
