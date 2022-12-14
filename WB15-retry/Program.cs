namespace WB15_retry
{
    /*
    このWEBアプリはWB15~19の内容を一部割愛しながら作成したものです。
    WB-20以降は時間に余裕があれば行おうと思います。

    ・目的
    手動でDBと接続しクエリを実行すること。
    よって、ChatLogsの主な機能はDB参照と新規追加のみです。

    ・流れ
    ０，SQLサーバーにテーブルを作成（クエリはWB-18にあり。）
    １，appsetting.jsonにDBへのパスを記載
    ２，ChatLogsControllerにてクエリを作成し、Commons/Dbcontext.cs内のReturnChatLogListやQueryExcuteへ引数として渡す。
    ３，Microsoft.Data.SqlClient;を使用しDBへ接続＆クエリ実行


    ・IAで頂いた参考書との主な相違点。
    １，自動生成はコントローラー/アクションメソッド名からViewを生成する際のみ
    ２，DB接続は手動、使うナゲットパッケージは「Microsoft.Data.SqlClient」
    ３，CSS、JSをwwwrootフォルダ内にお試し記載


    以下、WB-18のDB作成クエリを載せておきます。
USE [ChatApp]
 
CREATE TABLE [dbo].[ChatLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PostAt] [datetime2](7) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[UserId] [nvarchar](50) NULL,
 CONSTRAINT [PK_ChatLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
 
CREATE TABLE [dbo].[Users](
	[UserId] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[PasswordType] [tinyint] NOT NULL,
	[PasswordSalt] [nvarchar](255) NULL,
	[Password] [nvarchar](255) NULL,
	[IsAdministrator] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsAdministrator]  DEFAULT ((0)) FOR [IsAdministrator]
GO


     */
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //以下追記
            //MVCにする
            builder.Services.AddControllersWithViews();
            //ConectionStringセクション専用メソッド(appsetting.json)
            var test = builder.Configuration.GetConnectionString("DefaultConnection");
            //もしくは
            //var test = builder.Configuration.GetSection("ConnectionString").GetValue<string>("DefaultConnection");
            //ここまで
            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");
            //下記追記
            app.UseStaticFiles();//静的ファイル読み込み
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=ChatLogs}/{action=Index}/{id?}");
            //ここまで

            app.Run();
        }
    }
}