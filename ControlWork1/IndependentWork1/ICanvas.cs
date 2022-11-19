using System.Collections.Generic;
using System.Windows.Shapes;

namespace IndependentWork1
{
	public interface ICanvas
	{
		IEnumerable<System.Windows.Shapes.Line> GetLines(IEnumerable<IPoint> points);
		Ellipse GetCentralPoint(IPoint centralPoint);
	}
}
