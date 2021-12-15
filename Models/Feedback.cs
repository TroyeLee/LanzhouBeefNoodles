using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace LanzhouBeefNoodles.Models
{
    public class Feedback
    {
        [BindNever]
        public int Id { get; set; }
        [Required(ErrorMessage ="请留下你的名字")]
        [StringLength(50,ErrorMessage ="名字不能超过20个字")]
        public string Name { get; set; }

        [Required(ErrorMessage = "请留下你的email")]
        [StringLength(400, ErrorMessage = "意见不能超过50个字")]
        [DataType(DataType.EmailAddress,ErrorMessage ="请填写正确的email格式")]
        //[RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}))",ErrorMessage ="请填写正确的Email格式")]
        public string Email { get; set; }
        public DateTime CreateDateUTC { get; set; }
        [Required(ErrorMessage = "请留下你的反馈意见")]
        [StringLength(400, ErrorMessage = "意见不能超过200个字")]
        public string Message { get; set; }



    }
}
