using LAZADAKS.DATA.SERVICES.Clients;
using LAZADAKS.DATA.SERVICES;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyLazaDaks.Controllers.CHAT_CONTROLLER;
 

public class ChatController : BaseApiController
{
    private readonly IHubContext<ChatHub, IChatClient> _chatHub;

    public ChatController(IHubContext<ChatHub, IChatClient> chatHub)
    {
        _chatHub = chatHub;
    }


    [HttpPost("messages")]
    public async Task Post(ChatMessage message)
    {
        // run some logic...

        await _chatHub.Clients.All.ReceiveMessage(message);



    }



}
