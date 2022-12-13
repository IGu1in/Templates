using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Row
{
	public interface IStrategy
	{
		int GetNext(int firstItem, int secondItem, int i);
	}
}
