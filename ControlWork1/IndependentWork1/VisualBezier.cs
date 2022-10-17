using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace IndependentWork1
{
	public class VisualBezier : VisualCurve
	{
		private Bezier _bezier;
		public VisualBezier(Bezier bezier)
		{
			_bezier = bezier;
		}

		//public override void Draw(Canvas canvas)
		//{
		//	for (double t = 0; t < 1; t = t + 0.001)
		//	{
		//		var el = GetPoint(t);
		//		Ellipse elipse = new Ellipse();

		//		elipse.Width = 4;
		//		elipse.Height = 4;

		//		elipse.StrokeThickness = 2;
		//		elipse.Stroke = Brushes.Black;
		//		elipse.Margin = new Thickness(el.GetX(), el.GetY(), 0, 0);

		//		canvas.Children.Add(elipse);
		//	}
		//}

		public override IPoint GetPoint(double t)
		{
			
			return _bezier.GetPoint(t);
		}
	}
}
