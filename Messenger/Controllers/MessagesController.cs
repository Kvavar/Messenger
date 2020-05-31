using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Messenger.Infrastructure.Users;
using Messenger.Infrastructure.Messages;

namespace Messenger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IUserQueue _usersQueue;
        private readonly IMessageQueue _messegesQueue;

        public MessagesController(IUserQueue usersQueue, IMessageQueue messegesQueue)
        {
            _usersQueue = usersQueue;
            _messegesQueue = messegesQueue;
        }

        [HttpPost]
        public async Task<ActionResult> Send(long senderId, long receiverId, [FromBody] string message)
        {
            _usersQueue.Enqueue(new UserQueueItem());//check user
            _messegesQueue.Enqueue(new MessageQueueItem());
            return Accepted();
        }
    }
}
