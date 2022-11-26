using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using WB15_retry.Models;

namespace WB15_retry.Common
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

        //ChatLogリストが戻り値のメソッド
        //上記の「QueryExecute」を取り込みたいが、うまい方法が思い浮かばないのでひとまず保留します。
        public static List<ChatLog> ReturnChatLogList()
        {
            List<ChatLog> list = new List<ChatLog>();
            //実行したいクエリを記載
            var queryString = "SELECT Id, PostAt, Message, UserId FROM dbo.ChatLogs;";

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
