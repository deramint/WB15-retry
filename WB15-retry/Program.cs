namespace WB15_retry
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //以下追記
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
                pattern: "{controller=Chat}/{action=Index}/{id?}");
            //ここまで

            app.Run();
        }
    }
}