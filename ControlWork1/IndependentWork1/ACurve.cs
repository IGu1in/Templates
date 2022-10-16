namespace IndependentWork1
{
	public abstract class ACurve : ICurve
	{
		protected IPoint _a;
		protected IPoint _b;

		public ACurve(IPoint a, IPoint b)
		{
			_a = a;
			_b = b;
		}

		public abstract IPoint GetPoint(double t);
	}
}
