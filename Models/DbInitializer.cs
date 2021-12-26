using System.Collections.Generic;
using System.Linq;

namespace LanzhouBeefNoodles.Models
{
    /// <summary>
    /// 初始化数据库：1，添加Dbinitializer
    /// </summary>
    public static class DbInitializer
    {
        /// <summary>
        /// 初始化数据库:2,添加Seed函数，构造数据
        /// </summary>
        /// <param name="appDbContext"></param>
        public static void Seed(AppDbContext appDbContext)
        {
            if(appDbContext == null)
            {
                return;
            }
            if (appDbContext.Noodles.Any())
            {
                return;
            }
            //var _noodleList = new List<Noodle>()
            //{
            //    new Noodle{Id = 1, Name ="毛细",Price = 12 , ShortDescription = "如发丝般细",LongDescription = "真的好细好细",ImageURL="1"},
            //    new Noodle{Id = 2, Name ="细",Price = 10 , ShortDescription = "普通细",LongDescription = "还是挺细的",ImageURL="2"},
            //    new Noodle{Id = 3, Name ="三细",Price = 11 , ShortDescription = "有点粗了",LongDescription = "比细的粗点",ImageURL="3"},
            //    new Noodle{Id = 4, Name ="二细",Price = 10 , ShortDescription = "粗了",LongDescription = "粗的才有嚼劲",ImageURL="4"},
            //    new Noodle{Id = 5, Name ="二柱子",Price = 11 , ShortDescription = "太粗了",LongDescription = "粗的咬不动了",ImageURL=""},
            //    new Noodle{Id = 6, Name ="韭菜叶子",Price = 12 , ShortDescription = "扁的",LongDescription = "韭菜叶一样宽",ImageURL=""},
            //    new Noodle{Id = 7, Name ="薄宽",Price = 11 , ShortDescription = "开始宽了",LongDescription = "比韭菜叶宽一点",ImageURL=""},
            //    new Noodle{Id = 8, Name ="大宽",Price = 10 , ShortDescription = "裤带面",LongDescription = "太宽了",ImageURL=""},
            //    new Noodle{Id = 9, Name ="荞麦梭子",Price = 15 , ShortDescription = "立方体的",LongDescription = "比嘴巴还宽了",ImageURL=""},
            //    new Noodle{Id = 10, Name ="一窝丝",Price = 15 , ShortDescription = "这是啥",LongDescription = "好想知道",ImageURL=""},
            //    new Noodle{Id = 11, Name ="牛肉拉面",Price = 18 , ShortDescription = "不知道",LongDescription = "我也没吃过",ImageURL=""},
            //};
            appDbContext.AddRange(
                new Noodle { Name = "毛细", Price = 12, ShortDescription = "如发丝般细", LongDescription = "真的好细好细", ImageURL = "1" },
                new Noodle { Name = "细", Price = 10, ShortDescription = "普通细", LongDescription = "还是挺细的", ImageURL = "2" },
                new Noodle { Name = "三细", Price = 11, ShortDescription = "有点粗了", LongDescription = "比细的粗点", ImageURL = "3" },
                new Noodle { Name = "二细", Price = 10, ShortDescription = "粗了", LongDescription = "粗的才有嚼劲", ImageURL = "4" },
                new Noodle { Name = "二柱子", Price = 11, ShortDescription = "太粗了", LongDescription = "粗的咬不动了", ImageURL = "" },
                new Noodle { Name = "韭菜叶子", Price = 12, ShortDescription = "扁的", LongDescription = "韭菜叶一样宽", ImageURL = "" },
                new Noodle { Name = "薄宽", Price = 11, ShortDescription = "开始宽了", LongDescription = "比韭菜叶宽一点", ImageURL = "" },
                new Noodle { Name = "大宽", Price = 10, ShortDescription = "裤带面", LongDescription = "太宽了", ImageURL = "" },
                new Noodle { Name = "荞麦梭子", Price = 15, ShortDescription = "立方体的", LongDescription = "比嘴巴还宽了", ImageURL = "" },
                new Noodle {  Name = "一窝丝", Price = 15, ShortDescription = "这是啥", LongDescription = "好想知道", ImageURL = "" },
                new Noodle {  Name = "牛肉拉面", Price = 18, ShortDescription = "不知道", LongDescription = "我也没吃过", ImageURL = "" }
            );

            appDbContext.SaveChanges();
        }
    }
}
