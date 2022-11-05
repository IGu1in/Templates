namespace IndependentWork1
{
	public interface ICurve
	{
		public ICounter Counter { get; set; }
		IPoint GetPoint(double t);
		double? GetValue(double condition);
	}
}
