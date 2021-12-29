//EntityFramework 学习
using Microsoft.EntityFrameworkCore;
//Identity框架学习：1，引入库Identity
using Microsoft.AspNetCore.Identity;
//Identity框架学习：2，添加库，引入框架 Identity.Entity
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LanzhouBeefNoodles.Models
{
    /// <summary>
    /// Entity Framwork : 1,介乎你的代码和数据库之间的连接器，有点像路由器、代理服务器的意思，
    /// Entity Framwork : 2,作用：在数据库和代码之间引导数据的流动
    /// </summary>
    //public class AppDbContext:DbContext
    
    ///Identity 学习：1,将DbContext 改为IdentityDbContext ,传入泛型为用户模型，此处使用Identity的默认用户模型
    ///Identity 学习：当AppDbContext 继承了IdentityDbContext ,并且泛型类型为IdentityUser后，我们的数据库连接器，
    ///会自动为我们的系统添加用户表的映射，而且如果我们的用户表UserTable还不存在的话，IdentityContext也可以帮我们做数据库更新，自动帮我们添加用户表
    ///通过AppDbContext 我们的系统就能自动获取到用户信息了，而我们并不需要为此写一点代码，一切都是自动完成的，我们只需要让AppDbContext 继承IdentityDBContext就行了
    ///接下来，需要把身份验证嵌入到系统的请求通道中去，->StartUp
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        /// <summary>
        ///Entity Framwork : 3,需要依赖注入上下文的实例，实例可以通过构建函数的参数，传递进来
        ///因为构建函数需要外部访问，所以需要用Public关键词，在参数中，我们注入DbContextOptions，泛型类型是类本身，参数对象为options，
        ///最后还需要调用DbContext的父类，把options也传入父类
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }
        //Entity Framwork : 4,在我们的数据库上下文对象中，我们还需要指明哪一些模型需要映射到数据库中，
        //Entity Framwork : 5,对表进行映射的时候，需要使用复数形式
        public DbSet<Noodle> Noodles { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        //Entity Framwork : 6最后，需要把数据库上下文对象，依赖注入到系统的IOC容器中
    }
}
