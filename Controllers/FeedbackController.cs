using LanzhouBeefNoodles.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanzhouBeefNoodles.Controllers
{
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
