using Microsoft.EntityFrameworkCore;

namespace LanzhouBeefNoodles.Models
{
    /// <summary>
    /// Entity Framwork : 1,介乎你的代码和数据库之间的连接器，有点像路由器、代理服务器的意思，
    /// Entity Framwork : 2,作用：在数据库和代码之间引导数据的流动
    /// </summary>
    public class AppDbContext:DbContext
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
