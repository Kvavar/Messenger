using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Messenger.Infrastructure.Messages;

namespace Messenger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageQueue _messegesQueue;

        public MessagesController(IMessageQueue messegesQueue)
        {
            _messegesQueue = messegesQueue;
        }

        [HttpPost]
        public async Task<ActionResult> Send(long senderId, long receiverId, [FromBody] string message)
        {
            _messegesQueue.Enqueue(new MessageQueueItem());
            return Accepted();
        }
    }
}
