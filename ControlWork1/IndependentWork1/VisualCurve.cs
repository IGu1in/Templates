using System;
using System.Collections.Generic;
using System.Linq;

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

		public void ClearFragment(ICanvas canvas, IDrawable drawable)
		{
			if (drawable is null)
			{
				return;
			}

			double details = 10;
			var points = new List<IPoint>();

			for (double t = 0; t <= 1; t += 1.0 / details)
			{
				t = Math.Round(t, 5);
				var el = GetPoint(t);
				points.Add(el);
			}

			Lines = GetLines(points, canvas);

			if (_curve is Fragment fragment)
			{
				drawable.Clear(Lines, fragment.HasFirstPoint, fragment.HasLastPoint);
			}
			else
			{
				drawable.Clear(Lines);
			}
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

			if (_curve is Fragment fragment)
			{
				drawable.Draw(Lines, fragment.HasFirstPoint, fragment.HasLastPoint);
			}
			else
			{
				if(_curve is MoveTo move)
				{
					drawable.Draw(Lines, move.HasFirstPoint, move.HasLastPoint);
				}
				else
				{
					drawable.Draw(Lines);
				}
			}

			if (_curve is not Fragment && _curve is not MoveTo)
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
