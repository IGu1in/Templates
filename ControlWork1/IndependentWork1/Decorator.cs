using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndependentWork1
{
	public abstract class Decorator : ACurve
	{
		protected ACurve ACurve { get; private set; }
		protected Decorator(ACurve aCurve) : base(aCurve.A, aCurve.B)
		{
			ACurve = aCurve;
		}
	}
}
