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

namespace IndependentWork1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			var can = new Canvas
			{
				Width = 800,
				Height = 400
			};
			var p1 = new Point();
			p1.SetX(100);
			p1.SetY(20);
			var p2 = new Point();
			p2.SetX(40);
			p2.SetY(100);
			var p3 = new Point();
			p3.SetX(400);
			p3.SetY(40);
			var p4 = new Point();
			p4.SetX(50);
			p4.SetY(420);

			//var bez = new Bezier(p1, p2, p3, p4);
			//var vl = new VisualBezier(bez);
			//vl.Draw(can);
			//grid1.Children.Add(can);

			var line = new Line(p1, p2);
			var vl = new VisualLine(line);
			vl.Draw(can);
			grid1.Children.Add(can);

			Ellipse elipse = new Ellipse();

			elipse.Width = 4;
			elipse.Height = 4;

			elipse.StrokeThickness = 2;
			elipse.Stroke = Brushes.Red;
			elipse.Margin = new Thickness(p1.GetX(), p1.GetY(), 0, 0);

			can.Children.Add(elipse);

			Ellipse elipse2 = new Ellipse();

			elipse2.Width = 4;
			elipse2.Height = 4;

			elipse2.StrokeThickness = 2;
			elipse2.Stroke = Brushes.Green;
			elipse2.Margin = new Thickness(p2.GetX(), p2.GetY(), 0, 0);
			can.Children.Add(elipse2);

			//Ellipse elipse3 = new Ellipse();

			//elipse3.Width = 4;
			//elipse3.Height = 4;

			//elipse3.StrokeThickness = 2;
			//elipse3.Stroke = Brushes.Blue;
			//elipse3.Margin = new Thickness(p3.GetX(), p3.GetY(), 0, 0);
			//can.Children.Add(elipse3);

			//Ellipse elipse4 = new Ellipse();

			//elipse4.Width = 4;
			//elipse4.Height = 4;

			//elipse4.StrokeThickness = 2;
			//elipse4.Stroke = Brushes.Blue;
			//elipse4.Margin = new Thickness(p4.GetX(), p4.GetY(), 0, 0);
			//can.Children.Add(elipse4);
		}
	}
}
