using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace IndependentWork1
{
	public class Canva : ICanvas
	{
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
