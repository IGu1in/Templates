using System.Collections.Generic;

namespace IndependentWork1
{
	public interface ICanvas
	{
		IEnumerable<System.Windows.Shapes.Line> GetLines(IEnumerable<IPoint> points);
	}
}
