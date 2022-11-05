using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace IndependentWork1
{
	public class VisualCurve : ICurve
	{
		private ICurve _curve;
		public IDrawable Drawable { get; set; }
		public ICounter Counter { get; set; } = new LengthCounter();

		public VisualCurve(ICurve curve)
        {
			_curve = curve;
			Drawable = new DrawGreenColor();
        }

		public double? GetValue(double condition)
		{
			return _curve.GetValue(condition);
		}

		public void Draw(Canvas canvas)
        {
			if (Drawable is null)
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

			Drawable.Draw(canvas, points);

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

			Ellipse elipse = new Ellipse();
			elipse.Width = 4;
			elipse.Height = 4;
			elipse.StrokeThickness = 2;
			elipse.Stroke = Brushes.Red;
			elipse.Margin = new Thickness(centralPoint.GetX() - elipse.Width / 2,
				centralPoint.GetY() - elipse.Height / 2, 0, 0);
			canvas.Children.Add(elipse);
		}

		public IPoint GetPoint(double t)
        {
			return _curve.GetPoint(t);
        }
	}
}
