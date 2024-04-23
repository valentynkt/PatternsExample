using System;

namespace Bridge.Conceptual
{
    // Abstraction: Shape
    abstract class Shape
    {
        protected IColor color;

        public Shape(IColor color)
        {
            this.color = color;
        }

        public abstract void Draw();
    }

    // Concrete Abstraction: Circle
    class Circle : Shape
    {
        public Circle(IColor color) : base(color) { }

        public override void Draw()
        {
            Console.WriteLine($"Drawing Circle in {color.Fill()} color.");
        }
    }

    // Concrete Abstraction: Square
    class Square : Shape
    {
        public Square(IColor color) : base(color) { }

        public override void Draw()
        {
            Console.WriteLine($"Drawing Square in {color.Fill()} color.");
        }
    }

    // Implementor: Color
    interface IColor
    {
        string Fill();
    }

    // Concrete Implementor: Red
    class Red : IColor
    {
        public string Fill()
        {
            return "Red";
        }
    }

    // Concrete Implementor: Blue
    class Blue : IColor
    {
        public string Fill()
        {
            return "Blue";
        }
    }

    // Implementor: RenderingPlatform
    interface IRenderingPlatform
    {
        void RenderShape(Shape shape);
    }

    // Concrete Implementor: OpenGL
    class OpenGL : IRenderingPlatform
    {
        public void RenderShape(Shape shape)
        {
            Console.Write("Rendering using OpenGL: ");
            shape.Draw();
        }
    }

    // Concrete Implementor: DirectX
    class DirectX : IRenderingPlatform
    {
        public void RenderShape(Shape shape)
        {
            Console.Write("Rendering using DirectX: ");
            shape.Draw();
        }
    }
}
