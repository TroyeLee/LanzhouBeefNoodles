using LanzhouBeefNoodles.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using LanzhouBeefNoodles.ViewModels;
using System.Linq;

namespace LanzhouBeefNoodles.Controllers
{
    //[Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private INoodleRepository _noodleRepository;
        private IFeedbackRepository _feedbackRepository;
        public HomeController(INoodleRepository noodleRepository , IFeedbackRepository feedbackRepository)
        {
            _noodleRepository = noodleRepository;
            _feedbackRepository = feedbackRepository;
        }
        //[Route("[action]")]
        public IActionResult Index()
        {
            //var noodles = _noodleRepository.GetAllNoodles();
            var viewModle = new HomeViewModel()
            {
                feedbacks = _feedbackRepository.GetAllFeedbacks().ToList(),
                noodles = _noodleRepository.GetAllNoodles().ToList()
            };
            return View(viewModle);
        }

        //[Route("[action]")]
        public String About()
        {
            return "Hello From About";
        }

        //View学习：添加商品详情页面
        public IActionResult Detail(int id)
        {
            var noodle = _noodleRepository.GetNoodleById(id);
            return View(noodle);
        }
    }
}
