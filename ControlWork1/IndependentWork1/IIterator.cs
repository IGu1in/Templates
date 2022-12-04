namespace IndependentWork1
{
	public interface IIterator
	{
		bool IsCompleted { get; }
		ICurve First();
		ICurve Next();
	}
}
