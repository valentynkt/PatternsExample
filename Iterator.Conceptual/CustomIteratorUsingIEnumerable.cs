using System;
using System.Collections;
using System.Collections.Generic;

namespace Iterator.Conceptual.CustomIteratorUsingIEnumerable
{
    // we will use Iterator pattern and IEnumerable interface to create a custom iterator

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
    public interface SocialNetwork : IEnumerable<Profile>
    {
        IEnumerable<Profile> GetFriends(string profileId);
        IEnumerable<Profile> GetCoworkers(string profileId);
    }

    public class Facebook : SocialNetwork
    {
        // Simulated method to fetch friend or coworker profiles.
        public List<Profile> SocialGraphRequest(string profileId, string type)
        {
            // This would be replaced with an actual API request to the social network.
            // Here we simulate the result with hardcoded data.
            var profiles = new List<Profile>();
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

        public IEnumerable<Profile> GetFriends(string profileId)
        {
            var friends = SocialGraphRequest(profileId, "friends");
            foreach (var friend in friends)
            {
                yield return friend;
            }
        }

        public IEnumerable<Profile> GetCoworkers(string profileId)
        {
            var coworkers = SocialGraphRequest(profileId, "coworkers");
            foreach (var coworker in coworkers)
            {
                yield return coworker;
            }
        }

        // Implement IEnumerable<Profile> for iterating over all profiles.
        public IEnumerator<Profile> GetEnumerator()
        {
            // Return an enumerator that iterates through all profiles.
            foreach (var profile in SocialGraphRequest("", "all"))
            {
                yield return profile;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class FacebookIterator : IEnumerable<Profile>
    {
        private readonly List<Profile> _profiles;
        private readonly string _profileId;
        private readonly string _type;

        public FacebookIterator(List<Profile> profiles, string profileId, string type)
        {
            _profiles = profiles;
            _profileId = profileId;
            _type = type;
        }

        public IEnumerator<Profile> GetEnumerator()
        {
            // Depending on the _type, filter the list of profiles to friends or coworkers.
            foreach (var profile in _profiles)
            {
                if (ShouldBeIncluded(profile))
                {
                    yield return profile;
                }
            }
        }

        private bool ShouldBeIncluded(Profile profile)
        {
            // Apply filtering logic based on the type of iterator (friends or coworkers).
            return true; // Simplified for the example
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    // Your SocialSpammer and Application classes would remain largely the same,
    // except they would now work with the IEnumerable<Profile> interface
    // instead of the ProfileIterator interface.

    public class Application
    {
        private readonly SocialNetwork _network;
        private readonly SocialSpammer _spammer;

        public Application(SocialNetwork network)
        {
            _network = network;
            _spammer = new SocialSpammer();
        }

        public void SendSpamToFriends(string profileId, string message)
        {
            IEnumerable<Profile> friends = _network.GetFriends(profileId);
            _spammer.Send(friends, message);
        }

        public void SendSpamToCoworkers(string profileId, string message)
        {
            IEnumerable<Profile> coworkers = _network.GetCoworkers(profileId);
            _spammer.Send(coworkers, message);
        }
    }

    public class SocialSpammer
    {
        public void Send(IEnumerable<Profile> profiles, string message)
        {
            foreach (var profile in profiles)
            {
                Console.WriteLine($"Sending email to: {profile.Email}");
                // Here you would actually send the email.
            }
        }
    }
}
