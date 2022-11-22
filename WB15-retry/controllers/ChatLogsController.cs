using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;
using WB15_retry.common;
using WB15_retry.Models;

namespace WB15_retry.controllers
{
    public class ChatLogsController : Controller
    {


        public IActionResult Index()
        {
            string queryString = "SELECT Id, PostAt, Message, UserId FROM dbo.ChatLogs;";

            return View(DbConnect.DbOperation(queryString));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("PostAt,Message,UserId")] ChatLog chatLog)
        {
            string queryString = "insert into dbo.ChatLogs (PostAt, Message, UserId) values (" + chatLog.PostAt +","+ chatLog.Message +","+ chatLog.UserId + ");";
            DbConnect.DbOperation(queryString);

            return View(chatLog);
        }

    }
}
