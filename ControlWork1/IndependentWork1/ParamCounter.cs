namespace IndependentWork1
{
	public class ParamCounter : ICounter
	{
		public (bool, double) GetAnswer(double condition, double t, double length)
		{
			if (length >= condition)
			{
				return (true, t);
			}

			return (false, t);
		}
	}
}
