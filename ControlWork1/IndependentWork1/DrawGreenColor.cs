using System;
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
		public void Draw(Canvas canvas, IEnumerable<IPoint> points)
		{
			List<IPoint> pointList = points.ToList();

			if (points is null || pointList.Count == 0)
			{
				return;
			}

			Ellipse elipse = new Ellipse();
			elipse.Width = 4;
			elipse.Height = 4;
			elipse.StrokeThickness = 2;
			elipse.Stroke = Brushes.Green;
			elipse.Margin = new Thickness(pointList.FirstOrDefault().GetX() - elipse.Width / 2,
				pointList.FirstOrDefault().GetY() - elipse.Height / 2, 0, 0);
			canvas.Children.Add(elipse);

			var line1 = new System.Windows.Shapes.Line();
			line1.X1 = pointList.LastOrDefault().GetX();
			line1.Y1 = pointList.LastOrDefault().GetY();
			line1.X2 = line1.X1 - pointList.FirstOrDefault().GetX() / 2;
			line1.Y2 = line1.Y1 - pointList.FirstOrDefault().GetY() / 2;
			line1.Stroke = Brushes.Green;
			canvas.Children.Add(line1);
			var line2 = new System.Windows.Shapes.Line();
			line2.X1 = pointList.LastOrDefault().GetX();
			line2.Y1 = pointList.LastOrDefault().GetY();
			line2.X2 = line2.X1 - pointList.FirstOrDefault().GetX() / 2;
			line2.Y2 = line2.Y1 + pointList.FirstOrDefault().GetY() / 3;
			line2.Stroke = Brushes.Green;
			canvas.Children.Add(line2);

			for (var i = 0; i < pointList.Count - 1; i++)
			{
				var line = new System.Windows.Shapes.Line();
				line.X1 = pointList[i].GetX();
				line.Y1 = pointList[i].GetY();
				line.X2 = pointList[i + 1].GetX();
				line.Y2 = pointList[i + 1].GetY();
				line.Stroke = Brushes.Green;
				canvas.Children.Add(line);
			}
		}
	}
}
