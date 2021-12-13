using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanzhouBeefNoodles
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        //ע��������������
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.����ͨ��
        //���&����http����
        //�����м����Middleware������ÿһ���м����������һ���м����������������������ݸ���һ���м��
        //ͨ�����м����˳���������У����γ���Http�������ͨ�� request pipeline
        //���е��м������һ������ͨ�����м��������Ĵ�����ܽ�ϣ�����ͬ���м��֮������ͨ��Ƕ�׶�������ǿ��Ĵ�������
        //ÿ���м���ػ�����������֮��һ���м�����������Ӧ������������Ӧ������Ҫ��һ��Ҫ���
        //IwebHostEnvironment ��������
        //�������������ɻ��������Ի�����Ԥ������������������
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //û������·�ɣ�����URL��ô�仯��ϵͳʼ��ִ��App.Run�м����Ĵ��룬���Hello World
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //��ͳ·��
                //endpoints.MapDefaultControllerRoute();

                //����ע��·��
                //endpoints.MapControllers();

                //�����Զ���URL��·�ɵ�ӳ���ϵ
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=home}/{action=index}/{id?}"
                    );
                //endpoints.MapGet("/test", async context =>
                //{
                //    await context.Response.WriteAsync("Hello from test!");
                //});

                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}
