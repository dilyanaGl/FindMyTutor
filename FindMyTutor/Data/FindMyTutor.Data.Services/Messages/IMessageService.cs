using System;
using System.Collections.Generic;
using System.Text;
using FindMyTutor.Data.Models;


namespace FindMyTutor.Data.Services.Messages
{
    using DTO;

    public interface IMessageService
    {
        IEnumerable<Message> GetUserMessages(string id);

        void SendMessage(MessageDTO messageDTO);
    }
}
