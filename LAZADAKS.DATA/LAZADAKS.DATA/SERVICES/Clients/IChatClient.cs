

namespace LAZADAKS.DATA.SERVICES.Clients;

public  interface IChatClient
{

    Task ReceiveMessage(ChatMessage message);


}
