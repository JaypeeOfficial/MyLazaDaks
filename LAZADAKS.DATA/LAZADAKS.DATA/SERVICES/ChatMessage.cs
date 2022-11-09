

using System.ComponentModel.DataAnnotations.Schema;

namespace LAZADAKS.DATA.SERVICES;

public class ChatMessage
{
    public string User { get; set; }

    public string Message { get; set; }


    [Column(TypeName = "Date")]
    public DateTime TimeStamp { get; set; }

}
