using Microsoft.AspNetCore.Mvc;
using WB15_retry.common;

namespace WB15_retry.controllers
{
    public class ChatLogsController : Controller
    {


        public IActionResult Index()
        {
            string queryString = "SELECT Id, PostAt, Message, UserId FROM dbo.ChatLogs;";

            return View(DbConnect.IndexConnect(queryString));
        }
    }
}
