using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndependentWork1
{
	public interface ICounter
	{
		(bool, double) GetAnswer(double condition, double t, double length); 
	}
}
