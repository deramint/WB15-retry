using Microsoft.AspNetCore.Mvc;

namespace WB15_retry.controllers
{
    public class ChatLogsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
