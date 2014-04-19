using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MicroGrapher4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Curve> curves = new List<Curve>();

        public MainWindow()
        {

            InitializeComponent();

            Loaded += delegate
            {



                Graph newGraph = new Graph("x^2");
                Console.WriteLine(newGraph.ToString());

                /*
                foreach(Point point in newGraph.GetPoints() )
                    Console.WriteLine(point.ToString()+"," );
                */


                CartesianTable table = new CartesianTable(canvas, this);
                Curve curve = new Curve(newGraph, table);

                Console.WriteLine(curve.ToString());

                table.Refresh();
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
