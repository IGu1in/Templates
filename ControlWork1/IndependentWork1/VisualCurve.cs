using System.Windows.Controls;

namespace IndependentWork1
{
	public abstract class VisualCurve : IDrawable, ICurve
	{
		public abstract void Draw(Canvas canvas);

		public abstract IPoint GetPoint(double t);
	}
}
