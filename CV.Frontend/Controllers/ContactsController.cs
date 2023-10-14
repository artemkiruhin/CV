using Microsoft.AspNetCore.Mvc;

namespace CV.Frontend.Controllers {
    public class ContactsController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
