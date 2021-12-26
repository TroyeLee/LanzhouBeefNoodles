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
                //�������ݿ⣺3,���������У�������Ҫ����ϵͳ������������IOC Container����������ݿ����Ӷ���AppDbContext
                var services = scope.ServiceProvider;
                try
                {
                    //�������ݿ⣺4��������ݿ����Ӷ���AppDbContext
                    var context = services.GetRequiredService<AppDbContext>();
                    //��ʼ�����ݿ⣺5�����ó�ʼ�����ݿ⣬���йܷ�����Host����֮ǰ���ȳ���Ϊ���ǵ�ϵͳ��Ӳ�������
                    DbInitializer.Seed(context);
                }catch (Exception ex)
                {
                    //�������գ��Ժ������־
                }
            }
            //��ϵͳ��������
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
