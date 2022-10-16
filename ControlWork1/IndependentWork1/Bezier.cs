using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndependentWork1
{
	public class Bezier : ACurve
	{
		private IPoint _c;
		private IPoint _d;

		public Bezier(IPoint a, IPoint b, IPoint c, IPoint d) : base(a, b)
		{
			_c = c;
			_d = d;
		}

		public override IPoint GetPoint(double t)
		{
			var point = new Point();

			var x = Math.Pow((1 - t), 3) * _a.GetX() + 3 * t * Math.Pow((1 - t), 2) * _c.GetX()
				+ 3 * t * t * (1 - t) * _d.GetX() + Math.Pow(t, 3) * _b.GetX();
			var y = Math.Pow((1 - t), 3) * _a.GetY() + 3 * t * Math.Pow((1 - t), 2) * _c.GetY()
				+ 3 * t * t * (1 - t) * _d.GetY() + Math.Pow(t, 3) * _b.GetY();

			point.SetX(x);
			point.SetY(y);

			return point;
		}
	}
}
