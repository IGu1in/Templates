using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace IndependentWork1
{
	public class DrawBlackColor : IDrawable
	{
		public IEnumerable<Shape> CustomShapes
		{
			get { return _customShapes; }
		}
		private List<Shape> _customShapes;
		private Canvas _canvas;

		public DrawBlackColor(Canvas canvas)
		{
			_canvas = canvas;
			_canvas.Children.Clear();
			_customShapes = new List<Shape>();
		}

		public void DrawLine(IEnumerable<System.Windows.Shapes.Line> lines)
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
				line.Stroke = Brushes.Black;
				line.StrokeThickness = 2;
				line.StrokeDashArray = new DoubleCollection(new double[] { 2, 3 });
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
			var end = _canvas.Children.OfType<Shape>()
				.Where(c => "end".Equals(c.Tag))
				.FirstOrDefault();

			if (end is not null)
			{
				_canvas.Children.Remove(end);
			}
		}

		public void DrawStartPoint(double x, double y)
		{
			Rectangle rect = new Rectangle();
			rect.Width = 4;
			rect.Height = 4;
			rect.StrokeThickness = 5;
			rect.Stroke = Brushes.Black;
			rect.Margin = new Thickness(x - rect.Width / 2,
				y - rect.Height / 2, 0, 0);
			_customShapes.Add(rect);
			rect.Tag = "start";
			_canvas.Children.Add(rect);
		}

		public void DrawEndPoint(double x, double y)
		{
			Rectangle rect = new Rectangle();
			rect.Width = 4;
			rect.Height = 4;
			rect.Stroke = Brushes.Black;
			rect.StrokeThickness = 5;
			rect.Margin = new Thickness(x - rect.Width / 2,
				y - rect.Height / 2, 0, 0);
			_customShapes.Add(rect);
			rect.Tag = "end";
			_canvas.Children.Add(rect);
		}
	}
}
