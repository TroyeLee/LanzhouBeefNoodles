using LanzhouBeefNoodles.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LanzhouBeefNoodles
{
    public class Startup
    {
        //Entity Framwork : 10,ʹ��Appsettings.json�е�ConnectionString����Ҫ����һ����Configuration�ĵ��÷���
        public IConfiguration Configuration { get; }
        //Entity Framwork : 11,ͨ�����������Ĳ�������configurationע��ϵͳ��
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        //ע��������������
        public void ConfigureServices(IServiceCollection services)
        {
            //Entity Framwork : 7,���ǻ���Ҫ�����ݿ������ַ�����connectionstring�����,���ݿ�������Ϣconnectionstring ������AppSetting.json�ļ��С�
            //Entity Framwork : 12������connectionstring����Ϊ����Configuration.GetConnectionString("������")
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //Entity Framwork : 8,��������Ҫ����Ŀ������������ļ�Appsettings.json (�Ҽ������Ŀ������ӣ�appsettings.json)
            //Entity Framwork : 15��ע������,ע��MockNoodleRepository
            services.AddTransient<INoodleRepository, NoodleRepository>();
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();

            services.AddMvc();
            //����ע��
            //��ÿһ�η��������ʱ�򣬴���һ��ȫ�µ������ֿ⣬����������Զ�������
            //�ŵ㣺ÿ�����󶼻��ʼ��һ��ȫ�µ������ֿ⣬����ͬ������֮�䣬�����ֿ�������ȫ����������Ӱ��
            //services.AddTransient<INoodleRepository, MockNoodleRepository>();
            //��ϵͳ������ʱ�����ҽ�����һ�������ֿ⣬ÿ�δ������󣬶���ʹ��ͬһ�������ֿ�ʵ��
            //�ŵ㣺�����ã����ڹ���ȱ�㣺������Ⱦ
            //services.AddSingleton<INoodleRepository,MockNoodleRepository>();
            //���� AddTransient ��AddSingleton֮�䣬 ͬʱ�������������Transaction �ĸ���
            //��һϵ��������߲�����������ͬһ������Transaction�У�������������ҽ�����һ������ʵ���������������ϵͳ���Զ�ע���������
            //services.AddScoped<INoodleRepository,MockNoodleRepository>();
            //services.AddTransient<IFeedbackRepository , MockFeedbackRepository>();
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
            //·��ϵͳѧϰ��û������·�ɣ�����URL��ô�仯��ϵͳʼ��ִ��App.Run�м����Ĵ��룬���Hello World
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            app.UseRouting();
            
            //View���Styleѧϰ��app.UseEndpoints�м���ж�����������վ��·��ϵͳ��MVC·������Controller���Ƶģ���URLֻ��ӳ���������Controller��ǰ�˵�
            //��̬�ļ�������˵CSS�ļ���ͼƬ�ļ�����Ƶ�ļ�û���Լ���Ӧ��Controller���������κ�·�ɽ���ƥ�䣬�������еľ�̬�ļ����Ҳ���
            //������Ҫ��ӷ���̬�ļ����м��app.UseStaticFiles
            app.UseStaticFiles();

            //·��ϵͳѧϰ
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
