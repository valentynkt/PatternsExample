// Bridge Design Pattern
//
// Intent: Lets you split a large class or a set of closely related classes into
// two separate hierarchies—abstraction and implementation—which can be
// developed independently of each other.
//
//               A
//            /     \                        A         N
//          Aa      Ab        ===>        /     \     / \
//         / \     /  \                 Aa(N) Ab(N)  1   2
//       Aa1 Aa2  Ab1 Ab2

using System;

namespace Bridge.Conceptual
{
    class Program
    {
        static void Main(string[] args)
        {
            //    ConceptualExample();
            RemoteControllerExample();
        }

        private static void RemoteControllerExample()
        {
            Tv tv = new Tv();
            RemoteControl remote = new RemoteControl(tv);
            remote.TogglePower();

            Radio radio = new Radio();
            AdvancedRemoteControl advancedRemote = new AdvancedRemoteControl(radio);

        }

        static void ThreeDimensionsExample()
        {
            // Drawing a red circle using OpenGL
            Shape circle = new Circle(new Red());
            IRenderingPlatform opengl = new OpenGL();
            opengl.RenderShape(circle);

            // Drawing a blue square using DirectX
            Shape square = new Square(new Blue());
            IRenderingPlatform directx = new DirectX();
            directx.RenderShape(square);
        }
        private static void ConceptualExample()
        {
            Client client = new Client();

            Abstraction abstraction;
            // The client code should be able to work with any pre-configured
            // abstraction-implementation combination.
            abstraction = new Abstraction(new ConcreteImplementationA());
            client.ClientCode(abstraction);

            Console.WriteLine();

            abstraction = new ExtendedAbstraction(new ConcreteImplementationB());
            client.ClientCode(abstraction);
        }
    }
}
