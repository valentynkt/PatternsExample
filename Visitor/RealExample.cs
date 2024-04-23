namespace Visitor.Conceptual.ShapeExample
{
    using System;
    using System.Collections.Generic;

    // IShape acts as the Component interface for the Composite pattern.
    // It also serves as the Element interface for the Visitor pattern.
    public interface IShape
    {
        void Move(int x, int y);
        void Draw();
        void Accept(IVisitor visitor); // Accepts visitors, part of the Visitor pattern.
    }

    // Concrete shape classes, acting as Leaf in the Composite pattern.
    public class Dot : IShape
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public void Move(int x, int y)
        {
            X = x;
            Y = y;
            Console.WriteLine($"Dot moved to ({X}, {Y}).");
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing a dot at position ({X}, {Y}).");
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitDot(this); // Specific visit method for Dot.
        }
    }

    public class Circle : IShape
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Radius { get; set; } = 5;

        public void Move(int x, int y)
        {
            X = x;
            Y = y;
            Console.WriteLine($"Circle moved to ({X}, {Y}) with radius {Radius}.");
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing a circle at ({X}, {Y}) with radius {Radius}.");
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitCircle(this); // Specific visit method for Circle.
        }
    }

    public class Rectangle : IShape
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; set; } = 10;
        public int Height { get; set; } = 5;

        public void Move(int x, int y)
        {
            X = x;
            Y = y;
            Console.WriteLine($"Rectangle moved to ({X}, {Y}) with width {Width} and height {Height}.");
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing a rectangle at ({X}, {Y}) with width {Width} and height {Height}.");
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitRectangle(this); // Specific visit method for Rectangle.
        }
    }

    // CompoundShape acts as the Composite in the Composite pattern.
    // The composite class that can contain other shapes (both simple and composite).
    public class CompoundShape : IShape
    {
        private readonly List<IShape> children = [];

        public void Add(IShape shape)
        {
            children.Add(shape);
        }

        public void Remove(IShape shape)
        {
            children.Remove(shape);
        }

        public void Move(int x, int y)
        {
            foreach (var child in children)
            {
                child.Move(x, y); // Propagating the Move operation to all children.
            }
        }

        public void Draw()
        {
            foreach (var child in children)
            {
                child.Draw(); // Drawing each child in the composite.
            }
        }

        public void Accept(IVisitor visitor)
        {
            foreach (var child in children)
            {
                child.Accept(visitor); // Delegating the accept to all children.
            }
            visitor.VisitCompoundShape(this); // Visiting the compound shape itself.
        }
    }

    // The Visitor interface
    public interface IVisitor
    {
        void VisitDot(Dot dot);
        void VisitCircle(Circle circle);
        void VisitRectangle(Rectangle rectangle);
        void VisitCompoundShape(CompoundShape compoundShape);
    }

    // Concrete visitors implement different operations that can be performed on shape objects.
    public class XMLExportVisitor : IVisitor
    {
        public void VisitDot(Dot dot)
        {
            Console.WriteLine("Exporting Dot to XML.");
        }

        public void VisitCircle(Circle circle)
        {
            Console.WriteLine("Exporting Circle to XML.");
        }

        public void VisitRectangle(Rectangle rectangle)
        {
            Console.WriteLine("Exporting Rectangle to XML.");
        }

        public void VisitCompoundShape(CompoundShape compoundShape)
        {
            Console.WriteLine("Exporting Compound Shape to XML.");
        }
    }

    // Concrete visitor for displaying shapes in the console.
    public class ConsoleDisplayVisitor : IVisitor
    {
        public void VisitDot(Dot dot)
        {
            Console.WriteLine("Displaying Dot in console.");
            dot.Draw(); // Further actions can be added here, like logging info to the console.
        }

        public void VisitCircle(Circle circle)
        {
            Console.WriteLine("Displaying Circle in console.");
            circle.Draw(); // Drawing action shows up in the console.
        }

        public void VisitRectangle(Rectangle rectangle)
        {
            Console.WriteLine("Displaying Rectangle in console.");
            rectangle.Draw(); // Display rectangle details in the console.
        }

        public void VisitCompoundShape(CompoundShape compoundShape)
        {
            Console.WriteLine("Displaying Compound Shape in console.");
            compoundShape.Draw(); // Recursively draws all children in the console.
        }
    }

    // Client class using the shapes and visitors.
    public static class Application
    {
        public static void Run()
        {
            // Create simple shapes
            Dot dot = new Dot();
            Circle circle = new Circle();
            Rectangle rectangle = new Rectangle();

            // Create composite shapes
            CompoundShape compoundShape1 = new CompoundShape();
            compoundShape1.Add(dot);
            compoundShape1.Add(circle);

            CompoundShape compoundShape2 = new CompoundShape();
            compoundShape2.Add(rectangle);
            compoundShape2.Add(compoundShape1);  // Adding another composite shape to demonstrate nesting

            // Create visitors
            XMLExportVisitor xmlExporter = new XMLExportVisitor();
            ConsoleDisplayVisitor consoleDisplayer = new ConsoleDisplayVisitor();

            // Export the shapes to XML
            Console.WriteLine("Exporting shapes to XML:");
            compoundShape2.Accept(xmlExporter);

            // Display the shapes in the console
            Console.WriteLine("\nDisplaying shapes in console:");
            compoundShape2.Accept(consoleDisplayer);
        }
    }
}
