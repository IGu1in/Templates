﻿using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace IndependentWork1
{
	public class DrawGreenColor : IDrawable
	{
		public IEnumerable<Shape> CustomShapes { get; private set; }
		private Canvas _canvas;

		public DrawGreenColor(Canvas canvas)
		{
			_canvas = canvas;
			_canvas.Children.Clear();
			CustomShapes = new List<Shape>();
		}

		public void Draw(IEnumerable<System.Windows.Shapes.Line> lines, bool hasFirstPoint = true, bool hasLastPoint = true)//, IPoint? onePoint = null)
		{
			var customShapes = new List<Shape>();

			if (lines is null)
			{
				return;
			}

			List<System.Windows.Shapes.Line> linesList = lines.ToList();

			if (linesList.Count == 0)
			{
				return;
			}

			if (hasFirstPoint)
			{
				Ellipse elipse = new Ellipse();
				elipse.Width = 4;
				elipse.Height = 4;
				elipse.StrokeThickness = 2;
				elipse.Stroke = Brushes.Green;
				elipse.Margin = new Thickness(linesList.FirstOrDefault().X1 - elipse.Width / 2,
					linesList.FirstOrDefault().Y1 - elipse.Height / 2, 0, 0);
				customShapes.Add(elipse);
				_canvas.Children.Add(elipse);
			}

			if (hasLastPoint)
			{
				var line1 = new System.Windows.Shapes.Line();
				line1.X1 = System.Math.Round(linesList.LastOrDefault().X2);
				line1.Y1 = System.Math.Round(linesList.LastOrDefault().Y2);
				line1.X2 = System.Math.Round(line1.X1 - 10);
				line1.Y2 = System.Math.Round(line1.Y1 - 10);
				line1.Stroke = Brushes.Green;
				customShapes.Add(line1);
				_canvas.Children.Add(line1);
				var line2 = new System.Windows.Shapes.Line();
				line2.X1 = System.Math.Round(linesList.LastOrDefault().X2);
				line2.Y1 = System.Math.Round(linesList.LastOrDefault().Y2);
				line2.X2 = System.Math.Round(line2.X1 - 10);
				line2.Y2 = System.Math.Round(line2.Y1 + 10);
				line2.Stroke = Brushes.Green;
				customShapes.Add(line2);
				_canvas.Children.Add(line2);
			}

			foreach (var line in linesList)
			{
				line.Stroke = Brushes.Green;
				customShapes.Add(line);
				_canvas.Children.Add(line);
			}

			CustomShapes = customShapes;
		}

		public void DrawCentralPoint(Ellipse el)
		{
			_canvas.Children.Add(el);
		}
				
		public void Clear(IEnumerable<System.Windows.Shapes.Line> lines, bool hasFirstPoint = true, bool hasLastPoint = true)
		{
			var customShapes = new List<Shape>();

			if (lines is null)
			{
				return;
			}

			List<System.Windows.Shapes.Line> linesList = lines.ToList();

			if (linesList.Count == 0)
			{
				return;
			}

			if (hasFirstPoint)
			{
				Ellipse elipse = new Ellipse();
				elipse.Width = 4;
				elipse.Height = 4;
				elipse.StrokeThickness = 5;
				elipse.Stroke = Brushes.AliceBlue;
				elipse.Margin = new Thickness(linesList.FirstOrDefault().X1 - elipse.Width / 2,
					linesList.FirstOrDefault().Y1 - elipse.Height / 2, 0, 0);
				customShapes.Add(elipse);
				_canvas.Children.Add(elipse);
			}

			if (hasLastPoint)
			{
				var line1 = new System.Windows.Shapes.Line();
				line1.X1 = System.Math.Round(linesList.LastOrDefault().X2);
				line1.Y1 = System.Math.Round(linesList.LastOrDefault().Y2);
				line1.X2 = System.Math.Round(line1.X1 - 10);
				line1.Y2 = System.Math.Round(line1.Y1 - 10);
				line1.Stroke = Brushes.AliceBlue;
				line1.StrokeThickness = 5;
				customShapes.Add(line1);
				_canvas.Children.Add(line1);
				var line2 = new System.Windows.Shapes.Line();
				line2.X1 = System.Math.Round(linesList.LastOrDefault().X2);
				line2.Y1 = System.Math.Round(linesList.LastOrDefault().Y2);
				line2.X2 = System.Math.Round(line2.X1 - 10);
				line2.Y2 = System.Math.Round(line2.Y1 + 10);
				line2.Stroke = Brushes.AliceBlue;
				line2.StrokeThickness = 5;
				customShapes.Add(line2);
				_canvas.Children.Add(line2);
			}

			foreach (var line in linesList)
			{
				line.Stroke = Brushes.AliceBlue;
				customShapes.Add(line);
				_canvas.Children.Add(line);
			}
		}
	}
}
