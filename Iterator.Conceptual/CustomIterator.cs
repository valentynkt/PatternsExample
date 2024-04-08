using System.Collections.Generic;

namespace Iterator.Conceptual.Custom
{
    // Represents a user profile in the social network.
    public class Profile
    {
        public string Id { get; }
        public string Email { get; }

        public Profile(string id, string email)
        {
            Id = id;
            Email = email;
        }

        // ... Additional profile properties and methods ...
    }

    // The collection interface declares a factory method for producing iterators.
    public interface SocialNetwork
    {
        ProfileIterator CreateFriendsIterator(string profileId);
        ProfileIterator CreateCoworkersIterator(string profileId);
    }

    // The Facebook class is a concrete collection that implements the SocialNetwork interface.
    public class Facebook : SocialNetwork
    {
        // ... The bulk of the collection's code should go here ...

        // Methods for iterator creation.
        public ProfileIterator CreateFriendsIterator(string profileId)
        {
            return new FacebookIterator(this, profileId, "friends");
        }

        public ProfileIterator CreateCoworkersIterator(string profileId)
        {
            return new FacebookIterator(this, profileId, "coworkers");
        }

        // Method that simulates a social graph request to Facebook's backend system.
        public List<Profile> SocialGraphRequest(string profileId, string type)
        {
            // In a real app, you'd make an API request to Facebook here.
            // We'll just simulate the result.
            List<Profile> profiles = [];
            // Dummy data for illustration purposes
            if (type == "friends")
            {
                profiles.Add(new Profile("friend1", "friend1@example.com"));
                profiles.Add(new Profile("friend2", "friend2@example.com"));
            }
            else if (type == "coworkers")
            {
                profiles.Add(new Profile("coworker1", "coworker1@example.com"));
                profiles.Add(new Profile("coworker2", "coworker2@example.com"));
            }
            return profiles;
        }
    }

    // The common interface for all iterators.
    public interface ProfileIterator
    {
        Profile GetNext();
        bool HasMore();
    }

    // The concrete iterator class.
    public class FacebookIterator : ProfileIterator
    {
        private readonly Facebook facebook;
        private readonly string profileId;
        private readonly string type;
        private int currentPosition = 0;
        private List<Profile> cache;

        public FacebookIterator(Facebook facebook, string profileId, string type)
        {
            this.facebook = facebook;
            this.profileId = profileId;
            this.type = type;
        }

        private void LazyInit()
        {
            if (cache == null)
            {
                cache = facebook.SocialGraphRequest(profileId, type);
            }
        }

        public Profile GetNext()
        {
            if (HasMore())
            {
                return cache[currentPosition++];
            }
            else
            {
                return null;
            }
        }

        public bool HasMore()
        {
            LazyInit();
            return currentPosition < cache.Count;
        }
    }

    // SocialSpammer is the client class that sends messages via email to various profiles.
    public class SocialSpammer
    {
        public void Send(ProfileIterator iterator, string message)
        {
            while (iterator.HasMore())
            {
                Profile profile = iterator.GetNext();
                System.Console.WriteLine("Sending email to: " + profile.Email);
                // System.SendEmail(profile.GetEmail(), message);
            }
        }
    }

    // Application class configures collections and iterators and then passes them to the client code.
    public class Application
    {
        private SocialNetwork network;
        private SocialSpammer spammer;

        public void Config()
        {
            // This would be determined by external configuration, such as a settings file or user input.
            this.network = new Facebook();
            // if working with LinkedIn, network would be set to a new LinkedIn instance.

            this.spammer = new SocialSpammer();
        }

        public void SendSpamToFriends(Profile profile)
        {
            ProfileIterator iterator = network.CreateFriendsIterator(profile.Id);
            spammer.Send(iterator, "Very important message");
        }

        public void SendSpamToCoworkers(Profile profile)
        {
            ProfileIterator iterator = network.CreateCoworkersIterator(profile.Id);
            spammer.Send(iterator, "Very important message");
        }
    }
}
