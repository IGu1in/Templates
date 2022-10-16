using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace IndependentWork1
{
	public class VisualBezier : VisualCurve
	{
		public IPoint A { get; set; }
		public IPoint B { get; set; }
		public IPoint C { get; set; }
		public IPoint D { get; set; }
		public VisualBezier(IPoint a, IPoint b, IPoint c, IPoint d)
		{
			A = a;
			B = b;
			C = c;
			D = d;
		}

		public override void Draw(Canvas canvas)
		{
			for (double t = 0; t < 1; t = t + 0.001)
			{
				var el = GetPoint(t);
				Ellipse elipse = new Ellipse();

				elipse.Width = 4;
				elipse.Height = 4;

				elipse.StrokeThickness = 2;
				elipse.Stroke = Brushes.Black;
				elipse.Margin = new Thickness(el.GetX(), el.GetY(), 0, 0);

				canvas.Children.Add(elipse);
			}
		}

		public override IPoint GetPoint(double t)
		{
			var line = new Bezier(A, B, C, D);

			return line.GetPoint(t);
		}
	}
}
