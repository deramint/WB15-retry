using Microsoft.AspNetCore.Mvc;
using WB15_retry.Models;

namespace WB15_retry.controllers
{
    public class ChatLogsController : Controller
    {


        public IActionResult Index()
        {
            return View(ChatLog.DbConnect());
        }
    }
}
