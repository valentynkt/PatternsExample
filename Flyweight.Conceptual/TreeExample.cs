using System;
using System.Collections.Generic;

namespace Flyweight.Conceptual
{
    // The flyweight class contains a portion of the state of a tree.
    // These fields store values that are unique for each particular tree.
    // For instance, you won't find here the tree coordinates. But the texture
    // and colors shared between many trees are here. Since this data is usually
    // BIG, you'd waste a lot of memory by keeping it in each tree object.
    // Instead, we can extract texture, color, and other repeating data into a
    // separate object which lots of individual tree objects can reference.
    class TreeType
    {
        private readonly string name;
        private readonly string color;
        private readonly string texture;

        public TreeType(string name, string color, string texture)
        {
            this.name = name;
            this.color = color;
            this.texture = texture;
        }

        public void Draw(int x, int y)
        {
            // Create a bitmap of a given type, color & texture.
            // Draw the bitmap on the canvas at X and Y coords.
            Console.WriteLine($"Drawing tree type: {name}, Color: {color}, Texture: {texture} at ({x}, {y})");
        }
    }

    // Flyweight factory decides whether to re-use existing
    // flyweight or to create a new object.
    class TreeFactory
    {
        private static readonly Dictionary<string, TreeType> treeTypes = [];

        public static TreeType GetTreeType(string name, string color, string texture)
        {
            string key = $"{name}_{color}_{texture}";
            if (!treeTypes.ContainsKey(key))
            {
                treeTypes[key] = new TreeType(name, color, texture);
            }
            return treeTypes[key];
        }
    }

    // The contextual object contains the extrinsic part of the tree state.
    // An application can create billions of these since they are pretty small:
    // just two integer coordinates and one reference field.
    class Tree
    {
        private readonly int x, y;
        private readonly TreeType type;

        public Tree(int x, int y, TreeType type)
        {
            this.x = x;
            this.y = y;
            this.type = type;
        }

        public void Draw()
        {
            type.Draw(x, y);
        }
    }

    // The Tree and the Forest classes are the flyweight's clients.
    // You can merge them if you don't plan to develop the Tree class any further.
    class Forest
    {
        private readonly List<Tree> trees = [];

        public void PlantTree(int x, int y, string name, string color, string texture)
        {
            TreeType type = TreeFactory.GetTreeType(name, color, texture);
            Tree tree = new Tree(x, y, type);
            trees.Add(tree);
        }

        public void Draw()
        {
            foreach (var tree in trees)
            {
                tree.Draw();
            }
        }
    }
}
