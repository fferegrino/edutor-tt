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
    public class NewNotificationToNotificationEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<NwModels.NewNotification, Ent.Notification>()
                .ForMember(o => o.NotificationId, opt => opt.Ignore())
                .ForMember(o => o.SchoolUser, opt => opt.Ignore())
                .ForMember(o => o.Group, opt => opt.Ignore())
                .ForMember(o => o.Version, x => x.Ignore())
                .ForMember(o => o.CreationDate, x => x.Ignore())
                .ForMember(o => o.Details, x => x.Ignore())
                ;


            Mapper.CreateMap<Ent.Notification, RetModels.Notification>()
                .ForMember(x => x.Links, opt => opt.Ignore())
                 .ForMember(x => x.SchoolUserId, opt => opt.MapFrom(src => src.SchoolUser.UserId))
                 .ForMember(x => x.TotalStudents, opt => opt.MapFrom(v => v.Details != null ? v.Details.Count() : 0))
                 .ForMember(x => x.SeenStudents, opt => opt.MapFrom(v => v.Details != null ? v.Details.Count(t => t.Seen) : 0))
                ;

            Mapper.CreateMap<Ent.NotificationDetail, RetModels.StudentNotification>()
                .ForMember(x => x.Links, opt => opt.Ignore())
                .ForMember(d => d.SchoolUserName, x => x.MapFrom(s => s.Notification.SchoolUser.Name))
                .ForMember(d => d.GroupName, x => x.MapFrom(s => s.Notification.Group.Name))
                .ForMember(d => d.NotificationId, x => x.MapFrom(s => s.Notification.NotificationId))
                .ForMember(d => d.Text, x => x.MapFrom(s => s.Notification.Text))
                .ForMember(d => d.GroupId, x => x.MapFrom(s => s.Notification.Group.GroupId))
                .ForMember(d => d.SchoolUserId, x => x.MapFrom(s => s.Notification.SchoolUser.UserId))
                .ForMember(d => d.Name, x => x.MapFrom(s => s.Student.Name))
                .ForMember(d => d.StudentId, x => x.MapFrom(s => s.Student.StudentId))
                .ForMember(d => d.Curp, x => x.MapFrom(s => s.Student.Curp))
                ;


            Mapper.CreateMap<NwModels.NewSeenNotification, Ent.NotificationDetail>()
                .ForMember(o => o.Seen, opt => opt.Ignore())
                .ForMember(o => o.Notification, x => x.Ignore())
                .ForMember(o => o.Student, x => x.Ignore())
                .ForMember(o => o.Version, x => x.Ignore())
                ;
        }
    }
}
