using System;
using System.Collections.Generic;

namespace Flyweight.Conceptual
{
    // Represents a portion of the state shared among multiple tree objects.
    // Stores data like color and texture to avoid duplication in individual tree objects.
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

        // Draws the tree type at specified coordinates.
        public void Draw(int x, int y)
        {
            Console.WriteLine($"Drawing tree type: {name}, Color: {color}, Texture: {texture} at ({x}, {y})");
        }
    }

    // Decides whether to reuse existing flyweight or create a new one.
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

    // Contains the extrinsic part of the tree state.
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

        // Draws the tree using its type's attributes at its position.
        public void Draw()
        {
            type.Draw(x, y);
        }
    }

    // Represents a collection of trees, managing their creation and drawing.
    class Forest
    {
        private readonly List<Tree> trees = [];

        // Plants a tree at the specified position with the given attributes.
        public void PlantTree(int x, int y, string name, string color, string texture)
        {
            TreeType type = TreeFactory.GetTreeType(name, color, texture);
            Tree tree = new Tree(x, y, type);
            trees.Add(tree);
        }

        // Draws all trees in the forest.
        public void Draw()
        {
            foreach (var tree in trees)
            {
                tree.Draw();
            }
        }
    }

}
