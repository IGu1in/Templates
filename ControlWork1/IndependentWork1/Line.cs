namespace IndependentWork1
{
	public class Line : ACurve
	{
		public Line(IPoint a, IPoint b) : base(a, b)
		{
		}

		public override IPoint GetPoint(double t)
		{
			var point = new Point();

			var x = (1-t)*_a.GetX() + t*_b.GetX();
			var y = (1-t)*_a.GetY() + t*_b.GetY();

			point.SetX(x);
			point.SetY(y);

			return point;
		}
	}
}
