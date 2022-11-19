using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace IndependentWork1
{
	public class VisualCurve : ICurve
	{
		public List<System.Windows.Shapes.Line> Lines { get; private set; }
		private ICurve _curve;

		public VisualCurve(ICurve curve)
        {
			_curve = curve;
        }
		
		public void Draw(ICanvas canvas, IDrawable drawable)
        {
			if (drawable is null)
			{
				return;
			}

			double details = 10;
			var points = new List<IPoint>();

			for (double t = 0; t <= 1; t += 1 / details)
			{
				var el = GetPoint(t);
				points.Add(el);
			}

			Lines = GetLines(points, canvas);

			drawable.Draw(Lines);
		}

		public IPoint GetPoint(double t)
        {
			return _curve.GetPoint(t);
        }

		private List<System.Windows.Shapes.Line> GetLines (IEnumerable<IPoint> points, ICanvas canva)
		{
			return canva.GetLines(points).ToList();
		}
	}
}
