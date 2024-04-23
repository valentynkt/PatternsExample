// Proxy Design Pattern
//
// Intent: Lets you provide a substitute or placeholder for another object. A
// proxy controls access to the original object, allowing you to perform
// something either before or after the request gets through to the original
// object.

using System;

namespace Proxy.Conceptual
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
            var youTubeService = new ThirdPartyYouTubeClass();
            var youTubeProxy = new CachedYouTubeClass(youTubeService);
            var manager = new YouTubeManager(youTubeProxy);
            manager.ReactOnUserInput();
        }
        private static void ConceptualExample()
        {
            Client client = new Client();

            Console.WriteLine("Client: Executing the client code with a real subject:");
            RealSubject realSubject = new RealSubject();
            client.ClientCode(realSubject);

            Console.WriteLine();

            Console.WriteLine("Client: Executing the same client code with a proxy:");
            Proxy proxy = new Proxy(realSubject);
            client.ClientCode(proxy);
        }
    }
}
