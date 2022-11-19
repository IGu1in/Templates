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
		private readonly ConsoleLogger _logger;
		private Dictionary<string, List<IDrawable>> _drawables = new Dictionary<string, List<IDrawable>>();

		public MainWindow()
		{
			InitializeComponent();
			_logger = new ConsoleLogger();
		}

		private void SaveBlackClick(object sender, RoutedEventArgs e)
		{
			FileStream fs = File.Open(@"D:\blackCanvas.xaml", FileMode.Create);
			XamlWriter.Save(black, fs);
			fs.Close();

			if (_drawables.ContainsKey("black"))
			{
				_logger.Log(_drawables["black"]);
			}
		}

		private void SaveGreenClick(object sender, RoutedEventArgs e)
		{
			FileStream fs = File.Open(@"D:\greenCanvas.xaml", FileMode.Create);
			XamlWriter.Save(green, fs);
			fs.Close();

			if (_drawables.ContainsKey("green"))
			{
				_logger.Log(_drawables["green"]);
			}
		}

		private void GenerateClick(object sender, RoutedEventArgs e)
		{
			_drawables.Clear();
			var rand = new Random();

			var p1 = new Point();
			p1.SetX(rand.Next(200));
			p1.SetY(rand.Next(200));
			var p2 = new Point();
			p2.SetX(rand.Next(200));
			p2.SetY(rand.Next(200));
			var p3 = new Point();
			p3.SetX(rand.Next(200));
			p3.SetY(rand.Next(200));
			var p4 = new Point();
			p4.SetX(rand.Next(200));
			p4.SetY(rand.Next(200));

			var canva = new Canva();
			var drawBlack = new DrawBlackColor(black);
			var drawGreen = new DrawGreenColor(green);
			var line = new Line(p1, p2);
			var bez = new Bezier(p1, p2, p3, p4);
			var v2 = new VisualCurve(bez);
			var v1 = new VisualCurve(line);

			var listBlack = new List<IDrawable>();
			var listGreen = new List<IDrawable>();
			v2.Draw(canva, drawBlack);
			listBlack.Add(drawBlack);
			v1.Draw(canva, drawBlack);
			listBlack.Add(drawBlack);
			v2.Draw(canva, drawGreen);
			listGreen.Add(drawGreen);
			v1.Draw(canva, drawGreen);
			listGreen.Add(drawGreen);
			_drawables.Add("black", listBlack);
			_drawables.Add("green", listGreen);
		}
	}
}
