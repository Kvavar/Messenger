using Messenger.Entities.Queues;

namespace Messenger.Entities.Users
{
    public class User : IPayLoad
    {
        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; }
        public string Email { get; }
    }
}
