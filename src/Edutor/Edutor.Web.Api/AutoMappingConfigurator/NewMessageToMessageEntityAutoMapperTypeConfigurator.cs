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
        }
    }
}
