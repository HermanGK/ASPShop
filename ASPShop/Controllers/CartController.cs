using ASPShop.Data;
using ASPShop.Models;
using Microsoft.AspNetCore.Mvc;
using CloudIpspSDK;
using CloudIpspSDK.Checkout;



namespace ASPShop.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        public CartController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Main> items = new List<Main>();
            String sessionItems = HttpContext.Session.GetString("items_id") ?? "";
            if (string.IsNullOrEmpty(sessionItems))
            {
                ViewBag.NoItems = "Нет товаров в корзине";
                return View(items);
            }
                int[] itemsId = Array.ConvertAll(sessionItems.Split(','), int.Parse);
                items = _context.items.Where(el => itemsId.Contains(el.Id)).ToList();

            ViewBag.Summ = items.Sum(x => x.Price);
            TempData["Summary"] = ViewBag.Summ;


                return View(items);
            
        }


        public RedirectResult AddToCart(int id) 
        {
            String idStr = id.ToString();
            String sessionItems = HttpContext.Session.GetString("items_id") ?? "";
            if (!sessionItems.Contains(idStr))
            {
                if (!sessionItems.Equals(""))
                    sessionItems += "," + idStr;
                else sessionItems = idStr;

                HttpContext.Session.SetString("items_id", sessionItems);
            }

            return Redirect("/");
        }
        public RedirectResult DeleteFromCart(int id)
        {
            HttpContext.Session.Remove("items_id");
            return Redirect("/cart");
        }
        [HttpGet]
        public ActionResult Order()
        {
            ViewBag.sessionItems = HttpContext.Session.GetString("items_id") ?? "";
            return View();
        }
        [HttpPost]
        public IActionResult Order(Orders orders)
        {
            if(ModelState.IsValid)
            {
                _context.orders.Add(orders);
                _context.SaveChanges();

                Config.MerchantId = 1396424;
                Config.SecretKey = "test";

                var req = new CheckoutRequest
                {
                    order_id = Guid.NewGuid().ToString("N"),
                    amount = Convert.ToInt32(TempData["Summary"]) * 100,
                    order_desc = "checkout json demo",
                    currency = "UAH"
                };
                string url = "/";
                var resp = new Url().Post(req);
                if (resp.Error == null)
                {
                    url = resp.checkout_url; 
                }

                return Redirect(url);
            }
            ViewBag.sessionItems = HttpContext.Session.GetString("items_id") ?? "";
            return View();
        }   



    }

    
}
