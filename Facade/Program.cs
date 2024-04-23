// Facade Design Pattern
//
// Intent: Provides a simplified interface to a library, a framework, or any
// other complex set of classes.

namespace Facade.Conceptual
{
    class Program
    {
        static void Main(string[] args)
        {
            ConceptualExample();
        }

        private static void RealWorldExample()
        {
            VideoConverter converter = new VideoConverter();
            VideoFile mp4 = converter.Convert("funny-cats-video.ogg", "mp4");
            mp4.Save(); // Assuming VideoFile has a Save method
        }

        private static void ConceptualExample()
        {
            Client client = new Client();
            // The client code may have some of the subsystem's objects already
            // created. In this case, it might be worthwhile to initialize the
            // Facade with these objects instead of letting the Facade create
            // new instances.
            Subsystem1 subsystem1 = new Subsystem1();
            Subsystem2 subsystem2 = new Subsystem2();
            Facade facade = new Facade(subsystem1, subsystem2);
            Client.ClientCode(facade);
        }
    }
}
