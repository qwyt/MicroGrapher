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
        }

        public Point GetPoint(double value)
        {
            return new Point(value, _function.GetValueAtPoint(value));
        }


        public override string ToString()
        {
            return _function.ToString();
        }

    }
}
