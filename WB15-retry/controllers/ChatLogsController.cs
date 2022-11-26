using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;
using WB15_retry.Common;
using WB15_retry.Models;

namespace WB15_retry.controllers
{
    public class ChatLogsController : Controller
    {

        //ChatLog型のリストが帰ってくるのでそれをViewへ渡す。
        public IActionResult Index()
        {
            return View(DbContext.ReturnChatLogList());
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
