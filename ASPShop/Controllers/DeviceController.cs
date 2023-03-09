using ASPShop.Data;
using ASPShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace ASPShop.Controllers
{
    public class DeviceController : Controller
    {
        private readonly AppDbContext _context;
        public DeviceController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Main> items = _context.items.Where(el => el.Class == "Mouse" || el.Class == "Mousepads" || el.Class == "Keyboards").ToList();
            
            return View(items);
            
        }
    }
}
