using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace IndependentWork1
{
	public class DrawGreenColor : IDrawable
	{
		public IEnumerable<Shape> CustomShapes
		{
			get { return _customShapes; }
		}
		private List<Shape> _customShapes;
		private Canvas _canvas;

		public DrawGreenColor(Canvas canvas)
		{
			_canvas = canvas;
			_canvas.Children.Clear();
			_customShapes = new List<Shape>();
		}

		public void DrawLine(IEnumerable<System.Windows.Shapes.Line> lines)//, IPoint? onePoint = null)
		{
			if (lines is null)
			{
				return;
			}

			List<System.Windows.Shapes.Line> linesList = lines.ToList();

			if (linesList.Count == 0)
			{
				return;
			}			

			foreach (var line in linesList)
			{
				line.Stroke = Brushes.Green;
				_customShapes.Add(line);
				_canvas.Children.Add(line);
			}
		}

		public void DrawCentralPoint(Ellipse el)
		{
			_canvas.Children.Add(el);
		}
				
		public void ClearStartPoint()
		{
			var start = _canvas.Children.OfType<Shape>()
				.Where(c => "start".Equals(c.Tag))
				.FirstOrDefault();

			if (start is not null)
			{
				_canvas.Children.Remove(start);
			}
		}

		public void ClearEndPoint()
		{
			var end1 = _canvas.Children.OfType<Shape>()
				.Where(c => "end1".Equals(c.Tag))
				.FirstOrDefault();

			if (end1 is not null)
			{
				_canvas.Children.Remove(end1);
			}

			var end2 = _canvas.Children.OfType<Shape>()
				.Where(c => "end2".Equals(c.Tag))
				.FirstOrDefault();

			if (end2 is not null)
			{
				_canvas.Children.Remove(end2);
			}
		}

		public void DrawStartPoint(double x, double y)
		{
			Ellipse elipse = new Ellipse();
			elipse.Width = 4;
			elipse.Height = 4;
			elipse.StrokeThickness = 5;
			elipse.Stroke = Brushes.Green;
			elipse.Margin = new Thickness(x - elipse.Width / 2,
				y - elipse.Height / 2, 0, 0);
			_customShapes.Add(elipse);
			elipse.Tag = "start";
			_canvas.Children.Add(elipse);
		}

		public void DrawEndPoint(double x, double y)
		{
			var line1 = new System.Windows.Shapes.Line();
			line1.X1 = System.Math.Round(x);
			line1.Y1 = System.Math.Round(y);
			line1.X2 = System.Math.Round(line1.X1 - 10);
			line1.Y2 = System.Math.Round(line1.Y1 - 10);
			line1.Stroke = Brushes.Green;
			_customShapes.Add(line1);
			line1.Tag = "end1";
			_canvas.Children.Add(line1);
			var line2 = new System.Windows.Shapes.Line();
			line2.X1 = System.Math.Round(x);
			line2.Y1 = System.Math.Round(y);
			line2.X2 = System.Math.Round(line2.X1 - 10);
			line2.Y2 = System.Math.Round(line2.Y1 + 10);
			line2.Stroke = Brushes.Green;
			_customShapes.Add(line2);
			line2.Tag = "end2";
			_canvas.Children.Add(line2);
		}
	}
}
