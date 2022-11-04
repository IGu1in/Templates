namespace IndependentWork1
{
	public abstract class ACurve : ICurve
	{
		public IPoint A { private set; get; }
		public IPoint B { private set; get; }

		public ACurve(IPoint a, IPoint b)
		{
			A = a;
			B = b;
		}

		public abstract IPoint GetPoint(double t);
	}
}
