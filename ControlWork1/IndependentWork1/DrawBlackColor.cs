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
		public void Draw(Canvas canvas, IEnumerable<IPoint> points)
		{
			List<IPoint> pointList = points.ToList();

			if (points is null || pointList.Count == 0)
			{
				return;
			}

			Rectangle rect = new Rectangle();
			rect.Width = 4;
			rect.Height = 4;
			rect.Stroke = Brushes.Black;
			rect.Margin = new Thickness(pointList.FirstOrDefault().GetX() - rect.Width / 2,
				pointList.FirstOrDefault().GetY() - rect.Height / 2, 0, 0);
			canvas.Children.Add(rect);

			Rectangle rect2 = new Rectangle();
			rect2.Width = 4;
			rect2.Height = 4;
			rect2.Stroke = Brushes.Black;
			rect2.Margin = new Thickness(pointList.LastOrDefault().GetX() - rect2.Width / 2,
				pointList.LastOrDefault().GetY() - rect2.Height / 2, 0, 0);
			canvas.Children.Add(rect2);

			for (var i = 0; i < pointList.Count - 1; i++)
			{
				var line = new System.Windows.Shapes.Line();
				line.X1 = pointList[i].GetX();
				line.Y1 = pointList[i].GetY();
				line.X2 = pointList[i + 1].GetX();
				line.Y2 = pointList[i + 1].GetY();
				line.Stroke = Brushes.Black;
				line.StrokeThickness = 2;
				line.StrokeDashArray = new DoubleCollection(new double[] { 2, 3 });
				canvas.Children.Add(line);
			}
		}
	}
}
