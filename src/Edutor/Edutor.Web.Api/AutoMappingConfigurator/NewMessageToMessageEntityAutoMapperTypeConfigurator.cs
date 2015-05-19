using AutoMapper;
using Edutor.Common.TypeMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NwModels = Edutor.Web.Api.Models.NewModels;
using RetModels = Edutor.Web.Api.Models.ReturnTypes;
using Ent = Edutor.Data.Entities;

namespace Edutor.Web.Api.AutoMappingConfigurator
{
    public class NewMessageToMessageEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<NwModels.NewMessage, Ent.Message>()
                .ForMember(o => o.SentDate, opt => opt.Ignore())
                .ForMember(o => o.SeenDate, opt => opt.Ignore())
                .ForMember(o => o.MessageId, opt => opt.Ignore())
                .ForMember(o => o.ConversationId, opt => opt.Ignore())
                .ForMember(o => o.Version, x => x.Ignore())
                .ForMember(s => s.From, x => x.Ignore())
                .ForMember(s => s.To, x => x.Ignore())
                .ForMember(s => s.Conversation, x => x.Ignore())
                ;

            Mapper.CreateMap<Ent.Message, RetModels.Message>()
                .ForMember(t => t.ConversationId, opt => opt.MapFrom(x => x.Conversation.ConversationId))
                .ForMember(t => t.ToId, opt => opt.MapFrom(x => x.To.UserId))
                .ForMember(t => t.FromId, opt => opt.MapFrom(x => x.From.UserId))
                .ForMember(s => s.Links, x => x.Ignore())
                ;

            Func<Ent.Conversation, object> mapMessages = (conversation) =>
            {
                List<RetModels.Message> messages = new List<RetModels.Message>();
                foreach (var msg in conversation.Messages)
                    messages.Add(Mapper.Map<RetModels.Message>(msg));
                return messages;
            };

            Mapper.CreateMap<Ent.Conversation, RetModels.Conversation>()
                .ForMember(t => t.SenderName, opt => opt.MapFrom(x => x.User1.Name))
                .ForMember(t => t.SenderId, opt => opt.MapFrom(x => x.User1.UserId))
                .ForMember(t => t.RecipientName, opt => opt.MapFrom(x => x.User2.Name))
                .ForMember(t => t.RecipientId, opt => opt.MapFrom(x => x.User2.UserId))
                .ForMember(t => t.LastMessages, opt => opt.Ignore())
                .ForMember(t => t.Links, opt => opt.Ignore())
            ;
        }
    }
}
