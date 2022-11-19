namespace WB15_retry
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //�ȉ��ǋL
            builder.Services.AddControllersWithViews();
            //ConectionString�Z�N�V������p���\�b�h(appsetting.json)
            var test = builder.Configuration.GetConnectionString("DefaultConnection");
            //��������
            //var test = builder.Configuration.GetSection("ConnectionString").GetValue<string>("DefaultConnection");
            //�����܂�
            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");
            //���L�ǋL
            app.UseStaticFiles();//�ÓI�t�@�C���ǂݍ���
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Chat}/{action=Index}/{id?}");
            //�����܂�

            app.Run();
        }
    }
}