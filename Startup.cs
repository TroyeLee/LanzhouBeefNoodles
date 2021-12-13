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
        //注入依赖到容器中
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.请求通道
        //检查&处理http请求
        //交由中间件（Middleware）处理，每一个中间件都接受上一个中间件的输出，并将处理结果传递给下一个中间件
        //通过对中间件有顺序的组合排列，就形成了Http请求处理的通道 request pipeline
        //所有的中间件共用一个请求通道，中间件对请求的处理紧密结合，而不同的中间件之还可以通过嵌套而产生更强大的处理能力
        //每个中间件截获的请求对象都来之上一个中间件所输出的响应对象，所以在响应设置上要有一定要求的
        //IwebHostEnvironment 环境变量
        //开发环境，集成环境、测试环境、预发布环境、生产环境
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //没有启用路由，无论URL怎么变化，系统始终执行App.Run中间件里的代码，输出Hello World
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //传统路由
                //endpoints.MapDefaultControllerRoute();

                //特性注释路由
                //endpoints.MapControllers();

                //可以自定义URL与路由的映射关系
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
