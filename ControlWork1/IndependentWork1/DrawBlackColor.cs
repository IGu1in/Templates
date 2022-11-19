using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
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

		public void Draw(IEnumerable<System.Windows.Shapes.Line> lines)
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

			Rectangle rect = new Rectangle();
			rect.Width = 4;
			rect.Height = 4;
			rect.Stroke = Brushes.Black;
			rect.Margin = new Thickness(linesList.FirstOrDefault().X1 - rect.Width / 2,
				linesList.FirstOrDefault().Y1 - rect.Height / 2, 0, 0);
			customShapes.Add(rect);
			_canvas.Children.Add(rect);

			Rectangle rect2 = new Rectangle();
			rect2.Width = 4;
			rect2.Height = 4;
			rect2.Stroke = Brushes.Black;
			rect2.Margin = new Thickness(linesList.LastOrDefault().X2 - rect2.Width / 2,
				linesList.LastOrDefault().Y2 - rect2.Height / 2, 0, 0);
			customShapes.Add(rect2);
			_canvas.Children.Add(rect2);

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
	}
}
