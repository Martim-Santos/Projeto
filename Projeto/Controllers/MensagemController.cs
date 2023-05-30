using Microsoft.AspNetCore.Mvc;

namespace Projeto.Controllers {
    public class MensagemController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
