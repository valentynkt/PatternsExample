// Composite Design Pattern
//
// Intent: Lets you compose objects into tree structures and then work with
// these structures as if they were individual objects.

using System;

namespace Composite.Conceptual
{
    class Program
    {
        static void Main(string[] args)
        {
            RealWorldExample();
            ConceptualExample();
        }

        private static void RealWorldExample()
        {
            // Create an instance of ImageEditor
            ImageEditor editor = new ImageEditor();

            // Load initial graphics
            editor.Load();

            // Define selected components
            IGraphic[] selectedComponents = [new Dot(3, 4), new Dot(6, 7)];

            // Group selected components
            editor.GroupSelected(selectedComponents);
        }

        private static void ConceptualExample()
        {
            Client client = new Client();

            // This way the client code can support the simple leaf
            // components...
            Leaf leaf = new Leaf();
            Console.WriteLine("Client: I get a simple component:");
            client.ClientCode(leaf);

            // ...as well as the complex composites.
            Composite tree = new Composite();
            Composite branch1 = new Composite();
            branch1.Add(new Leaf());
            branch1.Add(new Leaf());
            Composite branch2 = new Composite();
            branch2.Add(new Leaf());
            tree.Add(branch1);
            tree.Add(branch2);
            Console.WriteLine("Client: Now I've got a composite tree:");
            client.ClientCode(tree);

            Console.Write("Client: I don't need to check the components classes even when managing the tree:\n");
            client.ClientCode2(tree, leaf);
        }
    }
}
