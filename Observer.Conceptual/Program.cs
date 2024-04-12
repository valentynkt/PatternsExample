// Observer Design Pattern
//
// Intent: Lets you define a subscription mechanism to notify multiple objects
// about any events that happen to the object they're observing.
//
// Note that there's a lot of different terms with similar meaning associated
// with this pattern. Just remember that the Subject is also called the
// Publisher and the Observer is often called the Subscriber and vice versa.
// Also the verbs "observe", "listen" or "track" usually mean the same thing.

namespace Observer.Conceptual
{
    class Program
    {
        static void Main(string[] args)
        {
            RealExample();
            ConceptualExample();
        }
        private static void RealExample()
        {
            var editor = new Editor();
            var logger = new LoggingListener("log.txt", "Someone has opened the file: %s");
            editor.Events.Subscribe("open", logger);

            var emailer = new EmailAlertsListener("admin@example.com", "File %s has been modified.");
            editor.Events.Subscribe("save", emailer);

            editor.OpenFile("test.txt");
            editor.SaveFile();
        }
        private static void ConceptualExample()
        {
            // The client code.
            var subject = new Subject();
            var observerA = new ConcreteObserverA();
            subject.Attach(observerA);

            var observerB = new ConcreteObserverB();
            subject.Attach(observerB);

            subject.SomeBusinessLogic();
            subject.SomeBusinessLogic();

            subject.Detach(observerB);

            subject.SomeBusinessLogic();
        }
    }
}
