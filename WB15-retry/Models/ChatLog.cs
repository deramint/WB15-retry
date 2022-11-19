using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace WB15_retry.Models
{
    public class ChatLog
    {
        public int Id { get; set; }
        public DateTime PostAt { get; set; }
        public string Message { get; set; }
        public string UserId { get; set; }


        public static List<ChatLog> DbConnect()
        {
            List<ChatLog> list = new List<ChatLog>();

            var path = WebApplication.CreateBuilder().Configuration.GetConnectionString("DefaultConnection");

            string queryString = "SELECT Id, PostAt, Message, UserId FROM dbo.ChatLogs;";

            using (SqlConnection connection = new SqlConnection(path))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    ChatLog chatLog = new ChatLog()
                    {
                        Id = (int)reader[0],
                        PostAt = (DateTime)reader[1],
                        Message = (string)reader[2],
                        UserId = (string)reader[3]
                    };
                    list.Add(chatLog);

                }
                // Call Close when done reading.
                reader.Close();
            }


            return list;
        }
    }
}
