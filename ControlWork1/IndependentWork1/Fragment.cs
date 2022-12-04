namespace IndependentWork1
{
	public class Fragment : Decorator
	{
		private readonly double _t1;
		private readonly double _t2;
		private readonly double koaf;
		public bool HasFirstPoint { get; private set; }
		public bool HasLastPoint { get; private set; }

		public Fragment(ACurve aCurve, double t1, double t2) : base(aCurve)
		{
			_t1 = t1;
			_t2 = t2;
			koaf = _t2-_t1!=0 
				?  1 / (_t2 - _t1)
				:double.MaxValue;
			HasFirstPoint = _t1 == 0 ? true : false;
			HasLastPoint = _t2 == 1 ? true : false;
		}

		public override IPoint GetPoint(double t)
		{
			if (koaf != double.MaxValue)
			{
				t = System.Math.Round(_t1 + t / koaf, 5);
			}
			else
			{
				t = _t2;
			}

			return ACurve.GetPoint(t);
		}
	}
}
