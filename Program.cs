using LanzhouBeefNoodles.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanzhouBeefNoodles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();
            using(var scope = host.Services.CreateScope())
            {
                //连接数据库：3,在主函数中，我们需要访问系统的依赖容器，IOC Container，来获得数据库连接对象AppDbContext
                var services = scope.ServiceProvider;
                try
                {
                    //连接数据库：4，获得数据库连接对象AppDbContext
                    var context = services.GetRequiredService<AppDbContext>();
                    //初始化数据库：5，调用初始化数据库，在托管服务器Host运行之前，先尝试为我们的系统添加测试数据
                    DbInitializer.Seed(context);
                }catch (Exception ex)
                {
                    //故意留空，以后添加日志
                }
            }
            //让系统运行起来
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
