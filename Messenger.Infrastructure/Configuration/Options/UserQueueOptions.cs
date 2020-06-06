namespace Messenger.Infrastructure.Configuration.Options
{
    public class UserQueueOptions
    {
        public readonly string SectionName = "UserQueue";
        public UserQueueOptions()
        {

        }

        public string InQueueName { get; set; }
        public string OutQueueName { get; set; }
        public string ConnectionString { get; set; }
    }
}
