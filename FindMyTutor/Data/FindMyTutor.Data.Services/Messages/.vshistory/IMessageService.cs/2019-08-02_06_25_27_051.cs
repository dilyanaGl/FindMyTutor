using System;
using System.Collections.Generic;
using System.Text;
using FindMyTutor.Data.Models;


namespace FindMyTutor.Data.Services.Messages
{
    using DTO;
    using System.Threading.Tasks;

    public interface IMessageService
    {
        IEnumerable<Message> GetUserMessages(string id);

        Task<int> SendMessage(MessageDTO messageDTO);

        Message GetMessage(int id);

        IEnumerable<Message> GetSentMessages(string id);

        IEnumerable<Message> GetUnreadMessages(string id);

        IEnumerable<Message> GetReadMessages(string id);

        Task<int> SetMessageToRead(int id);

        IEnumerable<Message> GetFullCorrespondence(string senderId, string receiverId);

        IEnumerable<MailMessageDTO> GetMail(string userId);

        
    }
}
