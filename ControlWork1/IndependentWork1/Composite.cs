using System;
using System.Collections.Generic;

namespace IndependentWork1
{
	public class Composite : ACurve
	{
		private List<ICurve> _curves;
		private bool isFirstTimeForSecondCurve = true;

		public Composite() : base(new Point(), new Point())
		{
			_curves = new List<ICurve>();
		}

		public override IPoint GetPoint(double t)
		{
			if (t >= 0 && t <= 0.5)
			{
				return _curves[0].GetPoint(t * 2);
			}

			if(t > 0.5 && t <= 1)
			{
				if (isFirstTimeForSecondCurve)
				{
					isFirstTimeForSecondCurve = false;

					return _curves[1].GetPoint(0);
				}

				return _curves[1].GetPoint((t - 0.5) * 2);
			}

			throw new ArgumentException();
		}

		public override void Add(ICurve curve)
		{
			_curves.Add(curve);
		}

		public override void Remove(ICurve curve)
		{
			_curves?.Remove(curve);
		}
	}
}
