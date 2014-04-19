using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MicroGrapher4
{
    class Curve: GraphicalObject
        /*
         *  Represents the graph on the canvas
         * 
         * 
         */ 
    {

        public Point[] points;
        CartesianTable table;
        Graph graph;
        Polyline myPolyline;
        //internal variables
        //

        public Curve(Graph graph, CartesianTable table)
        {
            this.graph = graph;

            this.table = table;

            table.Update += new CartesianTable.TableUpdatedEventHandler(OnUpdate);

            _GeneratePoints();
        }

        public void OnUpdate(CartesianTable table, EventArgs e){
            Console.WriteLine(table.XMod);
            _GeneratePoints();
            _Draw();
        }

        //internal methods
        private void _GeneratePoints()
        {
            double pointDistance = table.Scale;
            List<Point> pointsList = new List<Point>();
            for (double currentX = table.X0, currentY = table.Y0; currentX <= table.X1 && currentY <= table.Y1; currentX += pointDistance)
            {
                Point point =  graph.GetPoint(currentX);
                currentY = point.Y;
                pointsList.Add(point);
            }
            points = pointsList.ToArray<Point>();
        }

        private void _Draw()
        {

            Func<Point[], Point[]> TransformPoints = p =>
            {

                List<Point> newPointsList = new List<Point>();
                foreach (Point point in p)
                {
                    double newX = point.X * table.XMod;
                    double newY = point.Y * table.YMod;
                    if (newX <= table.XMod && newY <= table.YMod)
                        newPointsList.Add( new Point(newX, newY));
                }
               // Console.WriteLine(table.XMod+":xmod    " +newPointsList.ToString());
                return newPointsList.ToArray<Point>();
            };

            //Refactor awway :

            table.Canvas.Children.Remove(myPolyline);

            myPolyline = new Polyline();
            myPolyline.Stroke = System.Windows.Media.Brushes.SlateGray;
            myPolyline.StrokeThickness = 2;
            myPolyline.FillRule = FillRule.EvenOdd;

            PointCollection pointCollection = new PointCollection(TransformPoints(points));

            myPolyline.Points = pointCollection;
            table.Canvas.Children.Add(myPolyline);
        }

        
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            foreach (Point point in points)
                output.Append(", " + point.ToString());

            return output.ToString();
        }
     

    }

    abstract class GraphicalObject
        /*
         * parent for object representable on the table, ie curves, areas etc...
         */
    {
    }
}
