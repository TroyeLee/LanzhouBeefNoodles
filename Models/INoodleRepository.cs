using System.Collections;
using System.Collections.Generic;

namespace LanzhouBeefNoodles.Models
{
    public interface INoodleRepository
    {
        IEnumerable<Noodle> GetAllNoodles();
        Noodle GetNoodleById(int id);


    }
}
