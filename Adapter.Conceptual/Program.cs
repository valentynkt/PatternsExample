// Adapter Design Pattern
//
// Intent: Provides a unified interface that allows objects with incompatible
// interfaces to collaborate.

using System;

namespace Adapter.Conceptual
{
    class Program
    {
        static void Main(string[] args)
        {
            StockAppExample();
            ConceptualExample();
        }
        static void StockAppExample()
        {
            // Create an instance of the analytics library
            AnalyticsLibrary analyticsLibrary = new AnalyticsLibrary();

            // Create an XML-to-JSON adapter for the analytics library
            IAnalyticsLibrary adapter = new XmlToJsonAdapter(analyticsLibrary);

            // Create a stock market app instance using the adapter
            StockMarketApp stockMarketApp = new StockMarketApp(adapter);

            // Simulate receiving market data in XML format
            string xmlMarketData = "<marketData><symbol>ABC</symbol><price>100</price></marketData>";
            // Process the market data using the stock market app
            stockMarketApp.ProcessMarketData(xmlMarketData);
        }

        private static void ConceptualExample()
        {
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);

            Console.WriteLine("Adaptee interface is incompatible with the client.");
            Console.WriteLine("But with adapter client can call it's method.");

            Console.WriteLine(target.GetRequest());
        }
    }
}
