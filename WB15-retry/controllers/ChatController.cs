using Microsoft.AspNetCore.Mvc;

namespace WB15_retry.controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "チャットアプリケーションのはじまり";
            return View();
        }
    }
}
