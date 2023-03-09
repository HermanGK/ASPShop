using ASPShop.Data;
using ASPShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPShop.Controllers;

public class JacketController : Controller
{
    private readonly AppDbContext _context;


    public JacketController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        List<Main> items = _context.items.Where(el => el.Class == "jacket").ToList();
        return View(items);
        
    }
}
