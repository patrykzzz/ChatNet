using ChatNet.Application.Messages.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChatNet.API.Controllers
{
    [ApiController]
    public class MessagesController : BaseController
    {
        public MessagesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("api/messages")]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
