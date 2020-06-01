namespace Messenger.Infrastructure.Configuration.Options
{
    public class UserQueueOptions
    {
        public readonly string SectionName = "UserQueue";
        public UserQueueOptions()
        {

        }
        public string Name { get; set; }
        public string ConnectionString { get; set; }
    }
}
