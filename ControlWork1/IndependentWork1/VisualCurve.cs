using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace IndependentWork1
{
	public class VisualCurve : IDrawable, ICurve
	{
		private ICurve _curve;

        public VisualCurve(ICurve curve)
        {
			_curve = curve;
        }
		
		public void Draw(Canvas canvas)
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

		public IPoint GetPoint(double t)
        {
			return _curve.GetPoint(t);
        }
	}
}
