using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindMyTutor.Data.Services.Messages;
using FindMyTutor.Web.ViewModels.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FindMyTutor.Data.Services.DTO;
using FindMyTutor.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using FindMyTutor.Data.Services.Offers;
using FindMyTutor.Web.Helpers;
using FindMyTutor.Web.ViewModels.Messages;

namespace FindMyTutor.Web.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageService messageService;
        private readonly IOfferService offerService;
        private readonly IMapper mapper;
        private readonly UserManager<FindMyTutorUser> userManager;

        public MessageController(IMessageService messageService,
            IOfferService offerService,
            IMapper mapper,
            UserManager<FindMyTutorUser> userManager)
        {
            this.messageService = messageService;
            this.mapper = mapper;
            this.userManager = userManager;
            this.offerService = offerService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create(int id)
        {
            var model = new CreateMessageViewModel
            {
                OfferId = id
            };
            //this.ViewData["OfferId"] = id;
            return View(model);
        }

        [HttpPost]
        [Authorize]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(int id, CreateMessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var recipientId = this.offerService.GetOfferCreatorId(id);
                    if (recipientId == null)
                    {
                        this.TempData[Constants.ValidationState.Error] = Constants.Message.InvalidOffer;
                        return this.RedirectToAction("Details", "Offer", new { id = id });
                    }
                    var recipient = await this.userManager.FindByIdAsync(recipientId);
                    model.RecipientId = recipient.Id;
                    var dto = mapper.Map<CreateMessageViewModel, MessageDTO>(model);
                    var sender = await this.userManager.GetUserAsync(HttpContext.User);
                    dto.ReceiverId = recipientId;
                    dto.SenderId = sender.Id;
                    dto.OfferId = id;

                    int messageId = await this.messageService.SendMessage(dto);

                    var claim = new Claim("Message", messageId.ToString());
                    var setSender = await this.userManager.AddClaimAsync(sender, claim);
                    var setReceiver = await this.userManager.AddClaimAsync(recipient, claim);

                    this.TempData[Constants.ValidationState.Success] = Constants.Message.SuccessfulMessage;
                    return this.RedirectToAction("Details", "Offer", new { id = id });
                }
                catch (Exception ex)
                {
                    this.TempData[Constants.ValidationState.Error] = ex.Message;
                    return this.RedirectToAction("Details", "Offer", new { id = id });
                }
            }
            foreach (var error in ModelState.Values.SelectMany(p => p.Errors))
            {
                this.TempData[Constants.ValidationState.Error] += error.ErrorMessage + Environment.NewLine;
            }

            return this.View();

        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> All()
        {

            //string userId = this.userManager.GetUserId(HttpContext.User);

            //var unreadMessages = GenerateMessages(this.messageService.GetUnreadMessages(userId));

            //var sentMessages = GenerateMessages(this.messageService.GetSentMessages(userId));            

            //var model = new AllMessagesViewModel
            //{               
            //    SentMessages = sentMessages,
            //    UnreadMessages = unreadMessages

            //};

            string userId = this.userManager.GetUserId(HttpContext.User);
            var allSenders = this.messageService.GetMail(userId)
                .Select(async p =>
                {

                    var mapping = mapper.Map<MailMessageDTO, SenderViewModel>(p);
                    var sender = await this.userManager.FindByIdAsync(mapping.SenderId);
                    mapping.SenderName = sender.UserName;
                    return mapping;
                })
                .Select(p => p.Result)
                .ToArray();
            var model = new MailViewModel
            {
                Senders = allSenders
            };


            return this.View(model);
        }


        [HttpGet]
        //  [Authorize(Policy = Constants.Policy.MessageRequirement)]
        public async Task<IActionResult> Correspondence(string id)
        {
            try
            {
                string currentUserId = this.userManager.GetUserId(HttpContext.User);
                var allMessages = this.messageService.GetFullCorrespondence(id, currentUserId);

                var messages = allMessages
                    .Select(p =>
                    {
                        var model = mapper.Map<Message, MessageViewModel>(p);
                       
                        if (p.ReceiverId == currentUserId)
                        {
                            model.IsReceived = true;
                        }
                        return model;
                    })
                    .ToArray();
                string interlocutor = (await this.userManager.FindByIdAsync(id)).UserName;

                var respondModel = new RespondViewModel
                {
                    RecipientId = id
                }; 

                var viewModel = new CorrespondenceViewModel
                {
                    Interlocutor = interlocutor,
                    Messages = messages,
                    Respond = respondModel
                };

                return this.View(viewModel);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                this.TempData["Error"] = Constants.Message.InvalidOffer;
                return this.RedirectToAction("Index", "Home");
            }


        }

        [HttpPost]
        public async Task<IActionResult> Respond(string id, RespondViewModel model)
        {
            if (ModelState.IsValid)
            {
                var message = mapper.Map<RespondViewModel, MessageDTO>(model);
                message.SendDate = DateTime.Now;
                message.ReceiverId = id;
                message.SenderId = this.userManager.GetUserId(HttpContext.User);
                try
                {
                    var result = await this.messageService.SendMessage(message);
                }
                catch(Exception ex)
                {
                    this.TempData[Constants.ValidationState.Error] = ex.Message;
                }
                return this.RedirectToAction("Correspondence", new { id });
            }
            else
            {
                return this.RedirectToAction("Correspondence", new { id });
            }
        }


        [NonAction]
        private ICollection<MessageViewModel> GenerateMessages(IEnumerable<Message> messages)
        {
            return messages.Select(async message => await GenerateViewModelFromMesssage(message))
              .Select(p => p.Result)
              .OrderByDescending(p => p.SendDate)
              .ToArray();
        }

        [NonAction]
        private async Task<MessageViewModel> GenerateViewModelFromMesssage(Message message)
        {
            var model = mapper.Map<Message, MessageViewModel>(message);
            model.OfferTitle = this.offerService.GetTitleById(message.OfferId.Value);
            var sender = await this.userManager.FindByIdAsync(message.ReceiverId);
            model.SenderName = sender.FullName;
            return model;
        }


    }
}