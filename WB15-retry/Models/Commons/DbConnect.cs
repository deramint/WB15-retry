using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using WB15_retry.Models;

namespace WB15_retry.common
{
    //自作のDB接続クラス
    public class DbContext
    {
        //appsetting/jsonの接続文字列を持ってくる

        private static string Path { get; } = WebApplication.CreateBuilder().Configuration.GetConnectionString("DefaultConnection");
        
        //クエリ実行
        public static void QueryExecute(string queryString)
        {
            using (SqlConnection connection = new SqlConnection(Path))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteReader();
            }
        }

        public static List<ChatLog> ReturnChatLogList(string queryString)
        {
            List<ChatLog> list = new List<ChatLog>();

            using (SqlConnection connection = new SqlConnection(Path))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // readerに結果が入っているので、モデルインスタンスに代入しリストへ追加
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
                reader.Close();
            }
            return list;
        }
    }
}
