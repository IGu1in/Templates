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
		private readonly DrawBlackColor _drawBlack;
		private readonly DrawGreenColor _drawGreen;
		private readonly Canva _canva;
		private MoveTo _moveFragment; 
		private Line _line;
		private Bezier _bezier;
		private Dictionary<string, List<IDrawable>> _drawables = new Dictionary<string, List<IDrawable>>();

		public MainWindow()
		{
			InitializeComponent();
			_logger = new ConsoleLogger();
			_drawBlack = new DrawBlackColor(black);
			_drawGreen = new DrawGreenColor(green);
			_canva = new Canva();
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
			black.Children.Clear();
			green.Children.Clear();
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

			var line = new Line(p1, p2);
			_line = line;
			var bez = new Bezier(p1, p2, p3, p4);
			_bezier = bez;
			var v2 = new VisualCurve(bez);
			var v1 = new VisualCurve(line);

			var listBlack = new List<IDrawable>();
			var listGreen = new List<IDrawable>();
			v2.Draw(_canva, _drawBlack);
			listBlack.Add(_drawBlack);
			v1.Draw(_canva, _drawBlack);
			listBlack.Add(_drawBlack);
			v2.Draw(_canva, _drawGreen);
			listGreen.Add(_drawGreen);
			v1.Draw(_canva, _drawGreen);
			listGreen.Add(_drawGreen);
			_drawables.Add("black", listBlack);
			_drawables.Add("green", listGreen);
		}

		private void FragmentClick(object sender, RoutedEventArgs e)
		{
			var fragmentFirst = new Fragment(_line, 0, 0);
			var fragmentLast = new Fragment(_line, 1, 1);
			var clearCurve1 = new VisualCurve(fragmentFirst);
			var clearCurve2 = new VisualCurve(fragmentLast);
			clearCurve1.ClearFragment(_canva, _drawBlack);
			clearCurve1.ClearFragment(_canva, _drawGreen);
			clearCurve2.ClearFragment(_canva, _drawGreen);
			clearCurve2.ClearFragment(_canva, _drawBlack);
			var v1 = new VisualCurve(new MoveTo(fragmentFirst, _bezier.GetPoint(1)));
			var v2 = new VisualCurve(new MoveTo(fragmentLast, _bezier.GetPoint(0)));
			var listBlack = new List<IDrawable>();
			var listGreen = new List<IDrawable>();
			v1.Draw(_canva, _drawBlack);
			v2.Draw(_canva, _drawBlack);
			listBlack.Add(_drawBlack);
			v1.Draw(_canva, _drawGreen);
			v2.Draw(_canva, _drawGreen);
			listGreen.Add(_drawGreen);
		}

		private void MoveFragmentClick(object sender, RoutedEventArgs e)
		{
			var point = new Point();
			point.SetX(50);
			point.SetY(50);
			var fragmentFirst = new Fragment(_line, 0, 0.5);
			var clearCurve1 = new VisualCurve(fragmentFirst);
			clearCurve1.ClearFragment(_canva, _drawBlack);
			clearCurve1.ClearFragment(_canva, _drawGreen);
			var moving = new MoveTo(fragmentFirst, point);
			var v1 = new VisualCurve(moving);
			var listBlack = new List<IDrawable>();
			var listGreen = new List<IDrawable>();
			v1.Draw(_canva, _drawBlack);
			listBlack.Add(_drawBlack);
			v1.Draw(_canva, _drawGreen);
			listGreen.Add(_drawGreen);
			_moveFragment = moving;
		}

		private void ConcatClick(object sender, RoutedEventArgs e)
		{
			var fragmentFirst = new Fragment(_bezier, 0.5, 1);
			var clearCurve1 = new VisualCurve(fragmentFirst);
			clearCurve1.ClearFragment(_canva, _drawBlack);
			clearCurve1.ClearFragment(_canva, _drawGreen);
			var moving = new MoveTo(fragmentFirst, _moveFragment.GetPoint(1));
			var v1 = new VisualCurve(moving);
			var listBlack = new List<IDrawable>();
			var listGreen = new List<IDrawable>();
			v1.Draw(_canva, _drawBlack);
			listBlack.Add(_drawBlack);
			v1.Draw(_canva, _drawGreen);
			listGreen.Add(_drawGreen);
		}
	}
}
