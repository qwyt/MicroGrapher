using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroGrapher4
{
    public  interface isUpdatable{
        void OnUpdate();
    } 


    public static class Settings{

        public  const double GlobalPointsPrecision = 50d;
    }
}
