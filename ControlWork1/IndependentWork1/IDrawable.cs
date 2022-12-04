using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace IndependentWork1
{
	public interface IDrawable
	{
		public IEnumerable<Shape> CustomShapes { get; }
		void ClearStartPoint();
		void ClearEndPoint();
		void DrawLine(IEnumerable<System.Windows.Shapes.Line> lines);
		void DrawStartPoint(double x, double y);
		void DrawEndPoint(double x, double y);

		void DrawCentralPoint(Ellipse el);
	}
}