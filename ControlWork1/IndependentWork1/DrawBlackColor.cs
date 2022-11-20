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
		public IEnumerable<Shape> CustomShapes { get; private set; }
		private Canvas _canvas;

		public DrawBlackColor(Canvas canvas)
		{
			_canvas = canvas;
			_canvas.Children.Clear();
			CustomShapes = new List<Shape>();
		}

		public void Draw(IEnumerable<System.Windows.Shapes.Line> lines, bool hasFirstPoint = true, bool hasLastPoint = true)//, IPoint? onePoint = null)
		{
			var customShapes = new List<Shape>();

			if (lines is null)
			{
				return;
			}

			List<System.Windows.Shapes.Line> linesList = lines.ToList();

			if (linesList.Count == 0)
			{
				return;
			}

			if (hasFirstPoint)
			{
				Rectangle rect = new Rectangle();
				rect.Width = 4;
				rect.Height = 4;
				rect.Stroke = Brushes.Black;
				rect.Margin = new Thickness(linesList.FirstOrDefault().X1 - rect.Width / 2,
					linesList.FirstOrDefault().Y1 - rect.Height / 2, 0, 0);
				customShapes.Add(rect);
				_canvas.Children.Add(rect);
			}

			if (hasLastPoint)
			{
				Rectangle rect2 = new Rectangle();
				rect2.Width = 4;
				rect2.Height = 4;
				rect2.Stroke = Brushes.Black;
				rect2.Margin = new Thickness(linesList.LastOrDefault().X2 - rect2.Width / 2,
					linesList.LastOrDefault().Y2 - rect2.Height / 2, 0, 0);
				customShapes.Add(rect2);
				_canvas.Children.Add(rect2);
			}

			foreach (var line in linesList)
			{
				line.Stroke = Brushes.Black;
				line.StrokeThickness = 2;
				line.StrokeDashArray = new DoubleCollection(new double[] { 2, 3 });
				customShapes.Add(line);
				_canvas.Children.Add(line);
			}

			CustomShapes = customShapes;
		}

		public void DrawCentralPoint(Ellipse el)
		{
			_canvas.Children.Add(el);
		}

		public void Clear(IEnumerable<System.Windows.Shapes.Line> lines, bool hasFirstPoint = true, bool hasLastPoint = true)
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

			if (hasFirstPoint)
			{
				Rectangle rect = new Rectangle();
				rect.Width = 4;
				rect.Height = 4;
				rect.StrokeThickness = 5;
				rect.Stroke = Brushes.AliceBlue;
				rect.Margin = new Thickness(linesList.FirstOrDefault().X1 - rect.Width / 2,
					linesList.FirstOrDefault().Y1 - rect.Height / 2, 0, 0);
				_canvas.Children.Add(rect);
			}

			if (hasLastPoint)
			{
				Rectangle rect2 = new Rectangle();
				rect2.Width = 4;
				rect2.Height = 4;
				rect2.Stroke = Brushes.AliceBlue;
				rect2.StrokeThickness = 5;
				rect2.Margin = new Thickness(linesList.LastOrDefault().X2 - rect2.Width / 2,
					linesList.LastOrDefault().Y2 - rect2.Height / 2, 0, 0);
				_canvas.Children.Add(rect2);
			}

			foreach (var line in linesList)
			{
				line.Stroke = Brushes.AliceBlue;
				line.StrokeThickness = 5;
				line.StrokeDashArray = new DoubleCollection(new double[] { 2, 3 });
				_canvas.Children.Add(line);
			}
		}
	}
}
