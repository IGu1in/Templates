using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Row
{
	public interface IIterator
	{
		void Iterate(Iterator obj);
	}

	public delegate void Iterator(object obj);
}
