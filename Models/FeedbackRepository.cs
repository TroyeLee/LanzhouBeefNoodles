using System.Collections.Generic;

namespace LanzhouBeefNoodles.Models
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AppDbContext _appDbContext;
        public FeedbackRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void AddFeedback(Feedback feedback)
        {
            _appDbContext.Add<Feedback>(feedback);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Feedback> GetAllFeedbacks()
        {
            return _appDbContext.Feedbacks;
        }
    }
}
