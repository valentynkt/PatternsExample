using System;
using System.Collections.Generic;

namespace Composite.Conceptual
{
    // Component Interface
    interface IGraphic
    {
        void Move(int x, int y);
        void Draw();
    }

    // Leaf Classes
    class Dot : IGraphic
    {
        private int _x;
        private int _y;

        public Dot(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public void Move(int x, int y)
        {
            _x += x;
            _y += y;
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing a dot at ({_x}, {_y})");
        }
    }

    class Circle : IGraphic
    {
        private int _x;
        private int _y;
        private readonly int _radius;

        public Circle(int x, int y, int radius)
        {
            _x = x;
            _y = y;
            _radius = radius;
        }

        public void Move(int x, int y)
        {
            _x += x;
            _y += y;
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing a circle at ({_x}, {_y}) with radius {_radius}");
        }
    }

    // Composite Class
    class CompoundGraphic : IGraphic
    {
        private readonly List<IGraphic> _children = [];

        public void Add(IGraphic child)
        {
            _children.Add(child);
        }

        public void Remove(IGraphic child)
        {
            _children.Remove(child);
        }

        public void Move(int x, int y)
        {
            foreach (var child in _children)
            {
                child.Move(x, y);
            }
        }

        public void Draw()
        {
            Console.WriteLine("Drawing a compound graphic:");
            foreach (var child in _children)
            {
                child.Draw();
            }
            Console.WriteLine("Drawing a dashed rectangle using the bounding coordinates");
        }
    }

    // Client
    class ImageEditor
    {
        private readonly CompoundGraphic _all = new CompoundGraphic();

        public void Load()
        {
            _all.Add(new Dot(1, 2));
            _all.Add(new Circle(5, 3, 10));
            // ...
        }

        public void GroupSelected(IGraphic[] components)
        {
            var group = new CompoundGraphic();
            foreach (var component in components)
            {
                group.Add(component);
                _all.Remove(component);
            }
            _all.Add(group);
            // All components will be drawn.
            _all.Draw();
        }
    }
}
