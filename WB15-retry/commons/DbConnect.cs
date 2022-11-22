using Microsoft.Data.SqlClient;
using WB15_retry.Models;

namespace WB15_retry.common
{

    public class DbConnect
    {
        public static List<ChatLog> DbOperation(string queryString)
        {
            List<ChatLog> list = new List<ChatLog>();

            var path = WebApplication.CreateBuilder().Configuration.GetConnectionString("DefaultConnection");

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
