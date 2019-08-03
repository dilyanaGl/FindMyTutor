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
        private readonly IMapper mapper;

        public MessageService(IRepository<Message> messages,           
            IMapper mapper)
        {
            this.messages = messages;
            this.mapper = mapper;
            
        }

        public Message GetMessage(int id)
        {
           var message = this.messages.All().FirstOrDefault(p => p.Id == id);
           return message;
        }

        //public IEnumerable<Message> GetSentMessages(string id)
        //{
        //    return messages.All()
        //       .Where(p => p.SenderId == id)
        //       .ToArray();
        //}

        //public IEnumerable<Message> GetUnreadMessages(string id)
        //{
        //    return this.messages.All()
        //      .Where(p => p.ReceiverId == id && !p.IsRead)
        //      .ToArray();
        //}

        public IEnumerable<Message> GetUserMessages(string id)
        {
            return messages.All()
                .Where(p => p.ReceiverId == id)
                .ToArray();
        }

        //public IEnumerable<Message> GetReadMessages(string id)
        //{
        //    return this.messages.All()
        //        .Where(p => p.ReceiverId == id && p.IsRead)                
        //        .ToArray();
                
        //}

        public async Task<int> SendMessage(MessageDTO messageDTO)
        {
            var message = mapper.Map<MessageDTO, Message>(messageDTO);
            message.SendDate = DateTime.Now;
            int add = await this.messages.Add(message);
            int result = await this.messages.SaveChangesAsync();
            return message.Id;
        }

   

        public IEnumerable<Message> GetFullCorrespondence(string senderId, string receiverId)
        {
            return this.messages.All()
                .Where(p => (p.ReceiverId == receiverId && p.SenderId == senderId)
                || (p.SenderId == receiverId && p.ReceiverId == senderId))
                .OrderBy(p => p.SendDate)
                .ToArray();
        }

        public IEnumerable<MailMessageDTO> GetMail(string userId)
        {
            return this.messages.All()
                .Where(p => p.ReceiverId == userId)
                .GroupBy(p => p.SenderId)
                .Select((p) =>                
                     new MailMessageDTO()
                    {
                        SenderId = p.Key,
                        MessagesCount = p.Count(),
                        Topic = p.OrderBy(k => k.SendDate).FirstOrDefault().Subject
                    }                   
                )
                .ToArray();
        }
    }
}

