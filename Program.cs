

using System.Collections;
using System.Collections.Generic;

namespace dz11_Shape
{
    internal class Program
    {
        abstract class Shape
        {
            public ConsoleColor Color { get; set; }
            public int X { get; set; }
            public int Y { get; set; }

            public abstract void Draw();
        }
        class Rectangle : Shape
        {
            public int Width { get; set; }
            public int Height { get; set; }
            public override void Draw()
            {
                Console.ForegroundColor = Color;
                for (int i = 0; i < Height; i++)
                {
                    Console.SetCursorPosition(X, Y + i);
                    for (int j = 0; j < Width; j++)
                    {
                        Console.Write("*");
                    }
                }
                Console.ResetColor();
            }
        }
        class Rhombus : Shape
        {
            public int Size { get; set; }
            public override void Draw()
            {
                Console.ForegroundColor = Color;
                int halfSize = Size / 2;
                for (int i = 0; i < Size; i++)
                {
                    Console.SetCursorPosition(X + Math.Abs(halfSize - i), Y + i);
                    for (int j = 0; j < 2 * (halfSize - Math.Abs(halfSize - i)) + 1; j++)
                    {
                        Console.Write("*");
                    }
                }
                Console.ResetColor();
            }
        }

        
         class ShapeCollection : IEnumerable<Shape>
        {
            private List<Shape> _shapes = new List<Shape>();
            public void AddShape(Shape shape)
            {
                _shapes.Add(shape);
            }
            public void DrawAll()
            {
                foreach (var shape in _shapes)
                {
                    shape.Draw();
                }
            }
            IEnumerator<Shape> IEnumerable<Shape>.GetEnumerator() => _shapes.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => _shapes.GetEnumerator();


        }
        static void Main(string[] args)
        {
            var shapeCollection = new ShapeCollection();

            var rectangle = new Rectangle { X = 5, Y = 5, Width = 10, Height = 5, Color = ConsoleColor.Red };
            shapeCollection.AddShape(rectangle);
            var rhombus = new Rhombus { X = 20, Y = 5, Size = 5, Color = ConsoleColor.Green };
            shapeCollection.AddShape(rhombus);
            shapeCollection.DrawAll();
        }
    }
}
