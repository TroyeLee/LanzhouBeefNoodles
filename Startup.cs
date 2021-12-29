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
        //Entity Framwork : 10,使用Appsettings.json中的ConnectionString，需要加入一个对Configuration的调用方法
        public IConfiguration Configuration { get; }
        //Entity Framwork : 11,通过构建函数的参数，将configuration注入系统中
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        //注入依赖到容器中
        public void ConfigureServices(IServiceCollection services)
        {
            //Entity Framwork : 7,我们还需要把数据库连接字符串“connectionstring”添加,数据库配置信息connectionstring 来自于AppSetting.json文件中。
            //Entity Framwork : 12，将“connectionstring”改为调用Configuration.GetConnectionString("属性名")
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //Entity Framwork : 8,接下来需要给项目重新配置这个文件Appsettings.json (右键点击项目名，添加，appsettings.json)
            //Entity Framwork : 15，注入依赖,注释MockNoodleRepository
            services.AddTransient<INoodleRepository, NoodleRepository>();
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();

            services.AddMvc();
            //依赖注入
            //在每一次发起请求的时候，创建一个全新的面条仓库，请求结束后自动结束，
            //优点：每次请求都会初始化一个全新的面条仓库，而不同的请求之间，面条仓库数据完全独立，互不影响
            //services.AddTransient<INoodleRepository, MockNoodleRepository>();
            //在系统启动的时候，有且仅创建一个面条仓库，每次处理请求，都会使用同一个面条仓库实例
            //优点：简单易用，便于管理，缺点：数据污染
            //services.AddSingleton<INoodleRepository,MockNoodleRepository>();
            //介于 AddTransient 和AddSingleton之间， 同时引入了事务管理Transaction 的概念
            //将一系列请求或者操作，整合在同一个事务Transaction中，而这个事务有且仅创建一个面条实例，在事务结束后，系统会自动注销这个事务
            //services.AddScoped<INoodleRepository,MockNoodleRepository>();
            //services.AddTransient<IFeedbackRepository , MockFeedbackRepository>();
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
            //路由系统学习：没有启用路由，无论URL怎么变化，系统始终执行App.Run中间件里的代码，输出Hello World
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            app.UseRouting();
            
            //View添加Style学习：app.UseEndpoints中间件中定义了整个网站的路由系统，MVC路由是由Controller控制的，而URL只会映射给控制器Controller，前端的
            //静态文件，比如说CSS文件、图片文件、音频文件没有自己对应的Controller，不会与任何路由进行匹配，所以所有的静态文件都找不到
            //所以需要添加服务静态文件的中间件app.UseStaticFiles
            app.UseStaticFiles();

            //路由系统学习
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
