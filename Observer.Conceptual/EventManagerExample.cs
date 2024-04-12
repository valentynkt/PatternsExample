using System;
using System.Collections.Generic;

namespace Observer.Conceptual
{
    // Publisher
    public class EventManager
    {
        private readonly Dictionary<string, List<IEventListener>> listeners = [];

        public void Subscribe(string eventType, IEventListener listener)
        {
            if (!listeners.ContainsKey(eventType))
            {
                listeners[eventType] = [];
            }
            listeners[eventType].Add(listener);
        }

        public void Unsubscribe(string eventType, IEventListener listener)
        {
            if (listeners.ContainsKey(eventType))
            {
                listeners[eventType].Remove(listener);
            }
        }

        public void Notify(string eventType, string data)
        {
            if (listeners.ContainsKey(eventType))
            {
                foreach (var listener in listeners[eventType])
                {
                    listener.Update(data);
                }
            }
        }
    }

    // Subscriber interface
    public interface IEventListener
    {
        void Update(string filename);
    }

    // Concrete Publisher
    public class Editor
    {
        public EventManager Events { get; }

        private string file;

        public Editor()
        {
            this.Events = new EventManager();
        }

        public void OpenFile(string path)
        {
            this.file = path;
            this.Events.Notify("open", file);
        }

        public void SaveFile()
        {
            // File saving logic would go here...
            this.Events.Notify("save", file);
        }
    }

    // Concrete Subscriber
    public class LoggingListener : IEventListener
    {
        private readonly string logFilename;
        private readonly string message;

        public LoggingListener(string logFilename, string message)
        {
            this.logFilename = logFilename;
            this.message = message;
        }

        public void Update(string filename)
        {
            // Here you would write log to the file using logFilename
            Console.WriteLine($"Log: {message.Replace("%s", filename)}");
        }
    }

    public class EmailAlertsListener : IEventListener
    {
        private readonly string email;
        private readonly string message;

        public EmailAlertsListener(string email, string message)
        {
            this.email = email;
            this.message = message;
        }

        public void Update(string filename)
        {
            // Here you would send an email using email address
            Console.WriteLine($"Email to {email}: {message.Replace("%s", filename)}");
        }
    }
}
