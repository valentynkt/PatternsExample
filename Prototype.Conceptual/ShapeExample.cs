using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Conceptual
{
    // Base prototype.
    public abstract class Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Color { get; set; }
        // regular constructor
        protected Shape()
        {

        }

        protected Shape(Shape source) : this()
        {
            this.X = source.X;
            this.Y = source.Y;
            this.Color = source.Color;  
        }
        public abstract Shape Clone();
    }

    public class Rectangle : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle()
        {
            
        }
        // A parent constructor call is needed to copy private
        // fields defined in the parent class.
        public Rectangle(Rectangle source) : base(source)
        {
           this.Width = source.Width;
           this.Height = source.Height;
        }

        public override Shape Clone()
        {
           return new Rectangle(this);
        }
    }

    public class Circle : Shape
    {
        public int Radius { get; set; }

        public Circle()
        {
            
        }

        // A parent constructor call is needed to copy private
        // fields defined in the parent class.

        public Circle(Circle source) : base(source)
        {
            this.Radius = source.Radius;
        }

        public override Shape Clone()
        {
            return new Circle(this);
        }
    }
}
