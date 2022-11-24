using Microsoft.Data.SqlClient;
using WB15_retry.Models;

namespace WB15_retry.common
{
    //自作のDB接続クラス
    public class DbConnect
    {
        public static List<ChatLog> DbOperation(string queryString)
        {
            List<ChatLog> list = new List<ChatLog>();

            //appsetting/jsonの接続文字列を持ってくる
            var path = WebApplication.CreateBuilder().Configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection connection = new SqlConnection(path))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                //クエリ実行
                SqlDataReader reader = command.ExecuteReader();

                // セレクト文ならreaderに結果が入っているので、モデルインスタンスに代入しリストへ追加
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
            //リスト返却
            return list;
        }
    }
}
