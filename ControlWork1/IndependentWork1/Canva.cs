using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace IndependentWork1
{
	public class Canva : ICanvas
	{
		public Ellipse GetCentralPoint(IPoint centralPoint)
		{
			Ellipse elipse = new Ellipse();
			elipse.Width = 4;
			elipse.Height = 4;
			elipse.StrokeThickness = 2;
			elipse.Stroke = Brushes.Red;
			elipse.Margin = new Thickness(centralPoint.GetX() - elipse.Width / 2,
				centralPoint.GetY() - elipse.Height / 2, 0, 0);

			return elipse;
		}

		public IEnumerable<System.Windows.Shapes.Line> GetLines(IEnumerable<IPoint> points)
		{
			var linesList = new List<System.Windows.Shapes.Line>();
			List<IPoint> pointList = points.ToList();

			if (points is null || pointList.Count == 0)
			{
				return linesList;
			}

			for (var i = 0; i < pointList.Count - 1; i++)
			{
				var line = new System.Windows.Shapes.Line();
				line.X1 = pointList[i].GetX();
				line.Y1 = pointList[i].GetY();
				line.X2 = pointList[i + 1].GetX();
				line.Y2 = pointList[i + 1].GetY();
				line.Stroke = Brushes.Green;
				linesList.Add(line);
			}

			return linesList;
		}
	}
}
