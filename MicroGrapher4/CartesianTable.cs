using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MicroGrapher4
{
    class CartesianTable
    {
        public delegate void TableUpdatedEventHandler(CartesianTable sender, EventArgs e);

        public event TableUpdatedEventHandler Update;

        private double _x0;

        public double X0
        {
            get { return _x0; }
        }
        private double _y0;

        public double Y0
        {
            get { return _y0; }
        }

        private double _x1;

        public double X1
        {
            get { return _x1; }
        }
        private double _y1;

        public double Y1
        {
            get { return _y1; }
        }

        private double _scale;

        public double Scale
        {
            get { return _scale; }
        }

        private double _xMod;

        public double XMod
        {
            get { return _xMod; }
        }
        private double _yMod;

        public double YMod
        {
            get { return _yMod; }
        }


        private Canvas _canvas;
        public Canvas Canvas { get{return _canvas;}}

        public CartesianTable(Canvas canvas, MainWindow window)
        {
            window.SizeChanged += new System.Windows.SizeChangedEventHandler(Refresh);

            _canvas = canvas;

            //placeholders
            _x0 = 0;
            _y0 = 0;

            _x1 = 10d;
            _y1 = 10d;

            _scale = 0.25d;
            //
            //
            _xMod = canvas.ActualWidth;// / X1;
            _yMod = canvas.ActualHeight;// / Y1;
        }

        public void Refresh(object window, EventArgs e)
        {
            Refresh();
        }

        public void Refresh()
        {
            _xMod = Canvas.ActualWidth;// / X1;
            _yMod = Canvas.ActualHeight;// / Y1;
            Update(this, new EventArgs());
        }
    
    }
}
