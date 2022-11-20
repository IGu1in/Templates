namespace IndependentWork1
{
	public class Fragment : Decorator
	{
		private readonly double _t1;
		private readonly double _t2;
		private readonly double koaf;
		public double ParamForFirst { get { return _t1; } }
		public double ParamForLast { get { return _t2; } }
		public bool HasFirstPoint { get; private set; }
		public bool HasLastPoint { get; private set; }

		public Fragment(ACurve aCurve, double t1, double t2) : base(aCurve)
		{
			_t1 = t1;
			HasFirstPoint = _t1 == 0 ? true : false;
			_t2 = t2;
			HasLastPoint = _t2 == 1 ? true : false;
			koaf = _t2-_t1!=0 
				?  1 / (_t2 - _t1)
				:double.MaxValue;
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

		//public IEnumerable<IPoint> GetFragment(double t1, double t2)
		//{
		//	var listPoint = new List<IPoint>();
		//	double details = 10;

		//	for (double t = t1; t <= t2; t += 1 / details)
		//	{
		//		var el = GetPoint(t);
		//		listPoint.Add(el);
		//	}

		//	return listPoint;
		//}
	}
}
