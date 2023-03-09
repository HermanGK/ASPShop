using ASPShop.Data;
using ASPShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPShop.Controllers
{
    public class MousepadsController : Controller
    {
        private readonly AppDbContext _context;
        public MousepadsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Main> items = _context.items.Where(el => el.Class == "Mousepads").ToList();
            return View(items);

        }
    }
}
