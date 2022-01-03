using LanzhouBeefNoodles.Models;
using Microsoft.AspNetCore.Mvc;
//添加框架引用
using Microsoft.AspNetCore.Authorization;


namespace LanzhouBeefNoodles.Controllers
{
    [Authorize]
    public class FeedbackController : Controller
    {
        private IFeedbackRepository _feeedbackRepository;
        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            _feeedbackRepository = feedbackRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Feedback feedback)
        {
            //Tag Helper
            if (ModelState.IsValid)
            {
                _feeedbackRepository.AddFeedback(feedback);
                return RedirectToAction("FeedbackComplete");
            }
            return View();

        }

        public IActionResult FeedbackComplete()
        {
            return View();
        }
    }
}
