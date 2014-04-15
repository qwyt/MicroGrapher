using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MicroGrapher4
{
    class Graph
        /*
         *  Represents the abstract graph object
         * 
         * 
         */
    {
        private FunctionRepr _function;

        public string Function { set { _function = new FunctionRepr(value); } }

        public Graph(string function)
        {
            Function = function;
            new FunctionRepr("jaka");
        }


        public Point[] GetPoints(double from = 0d, double to = 10d, int count = 10)
        {
            var output = new Point[count];
            double iterator = (to - from)/count;
            double value = from;
            for (int i = 0; i < count; i++, value+=iterator)
            {
                output[i] = new Point(value, _function.GetValueAtPoint( value) );
            }
            return output;
        }
        public override string ToString()
        {
            return _function.ToString();
        }

    }
}
