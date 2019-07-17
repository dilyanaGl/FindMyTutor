using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using FindMyTutor.Data.Models;
using FindMyTutor.Common;
using AutoMapper;
namespace FindMyTutor.Data.Services.Messages
{
    using DTO;
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;

    public class MessageService : IMessageService
    {
        private readonly IRepository<Message> messages;
        private readonly IRepository<Offer> offers;
        private readonly IMapper mapper;

        public MessageService(IRepository<Message> messages,
            IRepository<Offer> offers,
            IMapper mapper)
        {
            this.messages = messages;
            this.mapper = mapper;
            this.offers = offers;
        }

        public async Task<Message> GetMessage(int id)
        {
           var message = this.messages.All().FirstOrDefault(p => p.Id == id);
            message.IsRead = true;
           
            await this.messages.SaveChangesAsync();
            return message;
        }

        public IEnumerable<Message> GetSentMessages(string id)
        {
            return messages.All()
               .Where(p => p.SenderId == id)
               .ToArray();
        }

        public IEnumerable<Message> GetUnreadMessages(string id)
        {
            return this.messages.All()
              .Where(p => p.ReceiverId == id && !p.IsRead)
              .ToArray();
        }

        public IEnumerable<Message> GetUserMessages(string id)
        {
            return messages.All()
                .Where(p => p.ReceiverId == id)
                .ToArray();
        }

        public IEnumerable<Message> GetReadMessages(string id)
        {
            return this.messages.All()
                .Where(p => p.ReceiverId == id && p.IsRead)                
                .ToArray();
                
        }

        public async Task<int> SendMessage(MessageDTO messageDTO)
        {
            var message = mapper.Map<MessageDTO, Message>(messageDTO);
            message.SendDate = DateTime.Now;
            await this.messages.Add(message);
            await this.messages.SaveChangesAsync();
            return message.Id;
        }

        public  async Task<int> SetMessageToRead(int id)
        {
            var message = this.messages.All()
                .FirstOrDefault(p => p.Id == id);

            message.IsRead = true;

            return await this.messages.SaveChangesAsync();
        }
    }
}
