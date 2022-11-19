using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WB15_retry.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace WB15_retry.controllers
{
    public class ChatLogsController : Controller
    {


        public IActionResult Index()
        {
            List<ChatLog> list = new List<ChatLog>();

            string path =
                "Data Source=(localdb)\\mssqllocaldb;" +
                "Initial Catalog=ChatApp;" +
                "Integrated Security=true";

            string queryString = "SELECT Id, PostAt, Message, UserId FROM dbo.ChatLogs;";

            using (SqlConnection connection = new SqlConnection(path))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    ReadSingleRow((IDataRecord)reader);
                    ChatLog chatLog = new ChatLog();
                    chatLog.Id = (int)reader[0];
                    chatLog.PostAt = (DateTime)reader[1];
                    chatLog.Message = (string)reader[2];
                    chatLog.UserId = (string)reader[3];
                    list.Add(chatLog);

                }

                // Call Close when done reading.
                reader.Close();
            }

            return View(list);
        }


        private static void ReadSingleRow(IDataRecord dataRecord)
        {
            Console.WriteLine(String.Format("{0}, {1}, {2}, {3}", dataRecord[0], dataRecord[1], dataRecord[2], dataRecord[3]));
        }
    }
}
