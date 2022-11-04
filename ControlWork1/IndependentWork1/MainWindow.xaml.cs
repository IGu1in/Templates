using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
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
		}

		private void SaveBlackClick(object sender, RoutedEventArgs e)
		{
			FileStream fs = File.Open(@"D:\blackCanvas.xaml", FileMode.Create);
			XamlWriter.Save(green, fs);
			fs.Close();
		}

		private void SaveGreenClick(object sender, RoutedEventArgs e)
		{
			FileStream fs = File.Open(@"D:\greenCanvas.xaml", FileMode.Create);
			XamlWriter.Save(green, fs);
			fs.Close();
		}

		private void GenerateClick(object sender, RoutedEventArgs e)
		{
			var p1 = new Point();
			p1.SetX(10);
			p1.SetY(20);
			var p2 = new Point();
			p2.SetX(300);
			p2.SetY(100);
			var p3 = new Point();
			p3.SetX(400);
			p3.SetY(50);
			var p4 = new Point();
			p4.SetX(50);
			p4.SetY(200);

			var drawGreen = new DrawGreenColor();
			var drawBlack = new DrawBlackColor();
			var line = new Line(p1, p2);
			var bez = new Bezier(p1, p2, p3, p4);
			var v2 = new VisualBezier(bez);
			v2.Drawable = drawBlack;
			var v1 = new VisualLine(line);
			v1.Drawable = drawBlack;
			v2.Draw(black);
			v1.Draw(black);
			v2.Drawable = drawGreen;
			v1.Drawable = drawGreen;
			v2.Draw(green);
			v1.Draw(green);
		}
	}
}
