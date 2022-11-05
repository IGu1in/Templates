namespace IndependentWork1
{
	public class LengthCounter : ICounter
	{
		public (bool, double) GetAnswer(double condition, double t, double length)
		{
			if (t >= condition)
			{
				return (true, length);
			}

			return (false, length);
		}
	}
}
