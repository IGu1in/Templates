using System;
using System.Collections.Generic;
using System.Windows.Shapes;

namespace IndependentWork1
{
	public class ConsoleLogger
	{
		public void Log(List<IDrawable> drawableList)
		{
			Console.WriteLine("--------------");
			foreach (IDrawable drawable in drawableList)
			{
				foreach (var shape in drawable.CustomShapes)
				{
					switch (shape)
					{
						case (Rectangle):
							LogRectangle(shape as Rectangle);
							break;

						case (Ellipse):
							LogElipse(shape as Ellipse);
							break;

						case (System.Windows.Shapes.Line):
							LogLine(shape as System.Windows.Shapes.Line);
							break;

						default:
							Console.WriteLine("Фигура не поддерживается");
							break;
					}
				}
			}
		}

		private void LogRectangle(Rectangle rect)
		{
			if(rect is null)
			{
				Console.WriteLine("Фигура не поддерживается");

				return;
			}

			Console.WriteLine($"Rect {rect.Width}, {rect.Height}, {rect.Stroke}, {rect.Margin}");
		}

		private void LogElipse(Ellipse el)
		{
			if(el is null)
			{
				Console.WriteLine("Фигура не поддерживается");
				return;
			}

			Console.WriteLine($"Elipse {el.Width}, {el.Height}, {el.Stroke}, {el.StrokeThickness}, {el.Margin}");
		}
		private void LogLine(System.Windows.Shapes.Line line)
		{
			if (line is null)
			{
				Console.WriteLine("Фигура не поддерживается");

				return;
			}

			Console.WriteLine($"Line {line.Stroke}, {line.X1}, {line.X2}, {line.Y1}, {line.Y2}");
		}
	}
}
