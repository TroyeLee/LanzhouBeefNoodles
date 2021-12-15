using System;
using System.Collections.Generic;

namespace LanzhouBeefNoodles.Models
{
    public class MockFeedbackRepository : IFeedbackRepository
    {
        private List<Feedback> _feedbacks;
        public MockFeedbackRepository()
        {
            if(_feedbacks == null)
            {
                InitializeFeedback();
            }
        }

        private void InitializeFeedback()
        {
            _feedbacks = new List<Feedback>
            {
                new Feedback{Id = 1, Name = "阿莱克斯" ,Email = "123@hotmail.com" , CreateDateUTC = DateTime.Today, Message = "1"},
                new Feedback{Id = 2, Name = "莱克斯" ,Email = "123@hotmail.com" , CreateDateUTC = DateTime.Today, Message = "2"},
                new Feedback{Id = 3, Name = "克斯" ,Email = "123@hotmail.com" , CreateDateUTC = DateTime.Today, Message = "3"},
                new Feedback{Id = 4, Name = "斯" ,Email = "123@hotmail.com" , CreateDateUTC = DateTime.Today, Message = "4"},
                new Feedback{Id = 5, Name = "阿" ,Email = "123@hotmail.com" , CreateDateUTC = DateTime.Today, Message = "5"},

            };
        }


        public IEnumerable<Feedback> GetAllFeedbacks()
        {
            return _feedbacks;
        }

        public void AddFeedback(Feedback feedback)
        {
            _feedbacks.Add(feedback);
        }
    }
}
