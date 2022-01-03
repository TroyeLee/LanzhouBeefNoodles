using System;
using LanzhouBeefNoodles.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(LanzhouBeefNoodles.Areas.Identity.IdentityHostingStartup))]
namespace LanzhouBeefNoodles.Areas.Identity
{
    //这个文件是用来配置Identity组件的
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                //Identity 学习：配置调整
                //需要使用ServicesCollection来注册身份认证服务IdentityService
                //使用默认配置来添加对身份认证系统的支持，然后调用AddEntityFramworkStores，并且传入AppDbContext作为泛型类型，以及EntityFramwork的支持
                services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<AppDbContext>();
            });
        }
    }
}