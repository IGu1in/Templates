using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace IndependentWork1
{
	public class VisualCurve : ICurve
	{
		public Shape FirstPoint { get; }
		public Shape LastPoint { get; }
		public IEnumerable<Shape> Lines { get; }
		private ICurve _curve;

		public VisualCurve(ICurve curve)
        {
			_curve = curve;
        }
		
		public void Draw(Canvas canvas, IDrawable drawable)
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

			drawable.Draw(canvas, points);
		}

		public IPoint GetPoint(double t)
        {
			return _curve.GetPoint(t);
        }
	}
}
