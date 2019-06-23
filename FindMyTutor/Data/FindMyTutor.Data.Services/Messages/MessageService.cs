using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using FindMyTutor.Data.Models;
using FindMyTutor.Common;

namespace FindMyTutor.Data.Services.Messages
{
    using DTO;

    public class MessageService : IMessageService
    {
        private readonly IRepository<Message> messages;

        public MessageService(IRepository<Message> messages)
        {
            this.messages = messages;
        }

        public IEnumerable<Message> GetUserMessages(string id)
        {
            return messages.All()
                .Where(p => p.ReceiverId == id)
                .ToArray();
        }     

        public void SendMessage(MessageDTO messageDTO)
        {
            
        }
    }
}
