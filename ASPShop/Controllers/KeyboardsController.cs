using ASPShop.Data;
using ASPShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPShop.Controllers
{
    public class KeyboardsController : Controller
    {
        private readonly AppDbContext _context;
        public KeyboardsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Main> items = _context.items.Where(el => el.Class == "Keyboards").ToList();
            return View(items);

        }
    }
}
