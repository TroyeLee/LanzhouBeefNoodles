using LanzhouBeefNoodles.Models;
using System.Collections.Generic;

namespace LanzhouBeefNoodles.ViewModels
{
    public class HomeViewModel
    {
        public IList<Noodle> noodles { get; set; }
        public IList<Feedback> feedbacks { get; set; }

    }
}
