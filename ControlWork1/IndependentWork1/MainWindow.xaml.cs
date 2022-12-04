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
		private Composite _composite;
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

			var p6 = new Point();
			p6.SetX(rand.Next(200));
			p6.SetY(rand.Next(200));
			var p7 = new Point();
			p7.SetX(rand.Next(200));
			p7.SetY(rand.Next(200));

			var line = new Line(p1, p2);
			_line = line;
			var bez = new Bezier(p1, p2, p3, p4);
			_bezier = bez;
			var composite = new Composite();
			var line2 = new Line(p6, p7);
			composite.Add(line);
			composite.Add(bez);
			composite.Add(line2);
			_composite = composite;
			var visualComposite = new VisualCurve(composite);
			var listBlack = new List<IDrawable>();
			var listGreen = new List<IDrawable>();
			visualComposite.Draw(_canva, _drawGreen, true, true, true);
			listGreen.Add(_drawGreen);
			visualComposite.Draw(_canva, _drawBlack, true, true, true);
			listBlack.Add(_drawBlack);
			_drawables.Add("black", listBlack);
			_drawables.Add("green", listGreen);
		}

		private void FragmentClick(object sender, RoutedEventArgs e)
		{
			var fragmentFirst = new Fragment(_line, 0, 0);
			var fragmentLast = new Fragment(_line, 1, 1);

			var clearCurve1 = new VisualCurve(fragmentFirst);
			var clearCurve2 = new VisualCurve(fragmentLast);
			clearCurve1.ClearStartPoint(_drawBlack);
			clearCurve1.ClearEndPoint(_drawBlack);
			clearCurve1.ClearStartPoint(_drawGreen);
			clearCurve1.ClearEndPoint(_drawGreen);
			clearCurve2.ClearStartPoint(_drawBlack);
			clearCurve2.ClearEndPoint(_drawBlack);
			clearCurve2.ClearStartPoint(_drawGreen);
			clearCurve2.ClearEndPoint(_drawGreen);

			var visualFirst = new VisualCurve(new MoveTo(fragmentFirst, _line.GetPoint(1)));
			var visualLast = new VisualCurve(new MoveTo(fragmentLast, _line.GetPoint(0)));

			visualFirst.Draw(_canva, _drawBlack, false, fragmentFirst.HasFirstPoint, fragmentFirst.HasLastPoint);
			visualLast.Draw(_canva, _drawBlack, false, fragmentLast.HasFirstPoint, fragmentLast.HasLastPoint);

			visualFirst.Draw(_canva, _drawGreen, false, fragmentFirst.HasFirstPoint, fragmentFirst.HasLastPoint);
			visualLast.Draw(_canva, _drawGreen, false, fragmentLast.HasFirstPoint, fragmentLast.HasLastPoint);
		}

		private void MoveFragmentClick(object sender, RoutedEventArgs e)
		{
			var point = new Point();
			point.SetX(50);
			point.SetY(50);
			var fragmentFirst = new Fragment(_line, 0, 0.5);
			var moving = new MoveTo(fragmentFirst, point);
			var v1 = new VisualCurve(moving);
			var listBlack = new List<IDrawable>();
			var listGreen = new List<IDrawable>();
			v1.Draw(_canva, _drawBlack, false, moving.HasFirstPoint, moving.HasLastPoint);
			listBlack.Add(_drawBlack);
			v1.Draw(_canva, _drawGreen, false, moving.HasFirstPoint, moving.HasLastPoint);
			listGreen.Add(_drawGreen);
			_moveFragment = moving;
		}

		private void ConcatClick(object sender, RoutedEventArgs e)
		{
			var fragmentFirst = new Fragment(_bezier, 0.5, 1);
			var clearCurve1 = new VisualCurve(fragmentFirst);
			var moving = new MoveTo(fragmentFirst, _moveFragment.GetPoint(1));
			var v1 = new VisualCurve(moving);
			var listBlack = new List<IDrawable>();
			var listGreen = new List<IDrawable>();
			v1.Draw(_canva, _drawBlack, false, moving.HasFirstPoint, moving.HasLastPoint);
			listBlack.Add(_drawBlack);
			v1.Draw(_canva, _drawGreen, false, moving.HasFirstPoint, moving.HasLastPoint);
			listGreen.Add(_drawGreen);
		}

		private void CountBazeCurve(object sender, RoutedEventArgs e)
		{
			var fragmentFirst = new Fragment(_bezier, 0.5, 1);
			var clearCurve1 = new VisualCurve(fragmentFirst);
			var moving = new MoveTo(fragmentFirst, _moveFragment.GetPoint(1));
			var v1 = new VisualCurve(moving);
			var listBlack = new List<IDrawable>();
			var listGreen = new List<IDrawable>();
			v1.Draw(_canva, _drawBlack, false, moving.HasFirstPoint, moving.HasLastPoint);
			listBlack.Add(_drawBlack);
			v1.Draw(_canva, _drawGreen, false, moving.HasFirstPoint, moving.HasLastPoint);
			listGreen.Add(_drawGreen);
		}
	}
}
