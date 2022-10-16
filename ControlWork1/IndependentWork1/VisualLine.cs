using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace IndependentWork1
{
	public class VisualLine : VisualCurve
	{
		public IPoint A { get; set; }
		public IPoint B { get; set; }
		public VisualLine(IPoint a, IPoint b)
		{
			A = a;
			B = b;
		}

		public override void Draw(Canvas canvas)
		{
			for (double t = 0; t < 1; t = t + 0.1) 
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
			var line = new Line(A, B);
			
			return line.GetPoint(t);
		}
	}
}
