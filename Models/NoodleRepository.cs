using System.Collections.Generic;
using System.Linq;

namespace LanzhouBeefNoodles.Models
{
    public class NoodleRepository : INoodleRepository
    {
        //Entity Framwork : 13,需要使用数据库连接对象来连接数据库,也就是刚刚的AppDbContext，因为数据库连接对象只是一个桥接器，所以它应该是Readonly的
        private readonly AppDbContext _appDbContext;
        //Entity Framwork : 14,在构建函数中，使用传参的方式将对象传入面条仓库
        public NoodleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Noodle> GetAllNoodles()
        {
            return _appDbContext.Noodles;
        }

        public Noodle GetNoodleById(int id)
        {
            return _appDbContext.Noodles.FirstOrDefault(n => n.Id == id);
        }
    }
}
