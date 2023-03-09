using ASPShop.Data;
using ASPShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPShop.Controllers
{
    public class MouseController : Controller
    {
        private readonly AppDbContext _context;
        public MouseController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Main> items = _context.items.Where(el => el.Class == "Mouse").ToList();
            return View(items);

        }
    }
}
