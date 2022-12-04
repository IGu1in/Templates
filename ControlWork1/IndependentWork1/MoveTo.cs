namespace IndependentWork1
{
	public class MoveTo : Decorator
	{
		private readonly IPoint _movePoint;
		private double _moveX;
		private double _moveY;
		public bool HasFirstPoint { get; private set; }
		public bool HasLastPoint { get; private set; }

		public MoveTo(ACurve aCurve, IPoint movePoint) : base(aCurve)
		{
			_movePoint = movePoint;

			var movingFirstPoint = ACurve.GetPoint(0);
			_moveX = movingFirstPoint.GetX() - _movePoint.GetX();
			_moveY = movingFirstPoint.GetY() - _movePoint.GetY();

			HasFirstPoint = true;
			HasLastPoint = true;

			if (aCurve is Fragment fragment)
			{
				HasFirstPoint = fragment.HasFirstPoint;
				HasLastPoint = fragment.HasLastPoint;
			}
		}

		public override IPoint GetPoint(double t)
		{
			var movingPoint = ACurve.GetPoint(t);
			movingPoint.SetX(movingPoint.GetX() - _moveX);
			movingPoint.SetY(movingPoint.GetY() - _moveY);

			return movingPoint;
		}
	}
}
