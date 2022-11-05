using System;

namespace IndependentWork1
{
	public abstract class ACurve : ICurve
	{
		public IPoint A { private set; get; }
		public IPoint B { private set; get; }
		public ICounter Counter { get; set; } = new LengthCounter();

		public ACurve(IPoint a, IPoint b)
		{
			A = a;
			B = b;
		}

		public abstract IPoint GetPoint(double t);

		public double? GetValue(double condition)
		{
			double step = 10;
			double length = 0;

			for (double i = 0; i < 1 - 1 / step; i += 1 / step)
			{
				var point = GetPoint(i);
				var point2 = GetPoint(i + 1 / step);
				length += Math.Sqrt(Math.Pow(point.GetX() - point2.GetX(), 2) + Math.Pow(point.GetY() - point2.GetY(), 2));

				(bool isEnd, double answer) = Counter.GetAnswer(condition, Math.Round(i + 1 / step, 3), length);

				if (isEnd is true)
				{
					return answer;
				}
			}

			return null;
		}
	}
}
