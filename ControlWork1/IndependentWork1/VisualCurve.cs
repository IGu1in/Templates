using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Windows.Controls;

namespace IndependentWork1
{
	public class VisualCurve : ICurve
	{
		public List<System.Windows.Shapes.Line> Lines { get; private set; }
		private ICurve _curve;
		public ICounter Counter { get; set; } = new LengthCounter();

		public VisualCurve(ICurve curve)
        {
			_curve = curve;
        }

		public double? GetValue(double condition)
		{
			return _curve.GetValue(condition);
		}

		public void ClearStartPoint(IDrawable drawable)
		{
			drawable.ClearStartPoint();
		}

		public void ClearEndPoint(IDrawable drawable)
		{
			drawable.ClearEndPoint();
		}

		public void Draw(ICanvas canvas, IDrawable drawable, bool hasCentralPoint, bool hasStartPoint, bool hasLastPoint)
        {
			if (drawable is null)
			{
				return;
			}

			double details = 1000;
			var points = new List<IPoint>();

			for (double t = 0; t <= 1; t += 1 / details)
			{
				var el = GetPoint(t);
				points.Add(el);
			}

			Lines = GetLines(points, canvas);

			if (hasStartPoint)
			{
				drawable.DrawStartPoint(Lines.FirstOrDefault().X1, Lines.FirstOrDefault().Y1);
			}

			drawable.DrawLine(Lines);			

			if (hasLastPoint)
			{
				drawable.DrawEndPoint(Lines.LastOrDefault().X2, Lines.LastOrDefault().Y2);
			}			

			if (hasCentralPoint)
			{
				DrawCentralPoint(canvas, drawable);
			}
		}

		public IPoint GetPoint(double t)
        {
			return _curve.GetPoint(t);
        }

		private void DrawCentralPoint(ICanvas canvas, IDrawable drawable)
		{
			_curve.Counter = new LengthCounter();
			var length = GetValue(1);

			if (length is null)
			{
				return;
			}

			_curve.Counter = new ParamCounter();
			var centralParam = GetValue((double)(length / 2));

			if (centralParam is null)
			{
				return;
			}

			var centralPoint = _curve.GetPoint((double)centralParam);

			drawable.DrawCentralPoint(canvas.GetCentralPoint(centralPoint));
		}

		private List<System.Windows.Shapes.Line> GetLines (IEnumerable<IPoint> points, ICanvas canva)
		{
			return canva.GetLines(points).ToList();
		}
	}
}
