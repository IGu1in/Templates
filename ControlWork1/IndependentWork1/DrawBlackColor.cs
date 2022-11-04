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
		public void Draw(Canvas canvas, List<IPoint> points)
		{
			if (points is null || points.Count == 0)
			{
				return;
			}

			Rectangle rect = new Rectangle();
			rect.Width = 4;
			rect.Height = 4;
			rect.Stroke = Brushes.Black;
			rect.Margin = new Thickness(points.FirstOrDefault().GetX() - rect.Width / 2,
				points.FirstOrDefault().GetY() - rect.Height / 2, 0, 0);
			canvas.Children.Add(rect);

			Rectangle rect2 = new Rectangle();
			rect2.Width = 4;
			rect2.Height = 4;
			rect2.Stroke = Brushes.Black;
			rect2.Margin = new Thickness(points.LastOrDefault().GetX() - rect2.Width / 2,
				points.LastOrDefault().GetY() - rect2.Height / 2, 0, 0);
			canvas.Children.Add(rect2);

			for (var i = 0; i < points.Count - 1; i++)
			{
				var line = new System.Windows.Shapes.Line();
				line.X1 = points[i].GetX();
				line.Y1 = points[i].GetY();
				line.X2 = points[i + 1].GetX();
				line.Y2 = points[i + 1].GetY();
				line.Stroke = Brushes.Black;
				line.StrokeThickness = 2;
				line.StrokeDashArray = new DoubleCollection(new double[] { 2, 3 });
				canvas.Children.Add(line);
			}
		}
	}
}
