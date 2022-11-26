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
            //実行したいクエリを記載
            var queryString = "SELECT Id, PostAt, Message, UserId FROM dbo.ChatLogs;";

            //ChatLog型のリストが帰ってくるのでそれをViewへ渡す。
            return View(DbContext.ReturnChatLogList(queryString));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //Bindでフォームから入力された値をchatlogインスタンスへ代入
        public IActionResult Create([Bind("Message,UserId")] ChatLog chatLog)
        {
            if(chatLog.Message != null)
            {
                //現在時刻を代入
                chatLog.PostAt = DateTime.Now;
                //インサート文を作成し実行
                var queryString = "insert into dbo.ChatLogs(PostAt, Message, UserId)values('" + chatLog.PostAt + "','" + chatLog.Message + "','" + chatLog.UserId + "');";
                DbContext.QueryExecute(queryString);
            }
            //成功しても失敗してもリダイレクト
            return RedirectToAction(nameof(Index));
        }

    }
}
