﻿using AutoMapper;
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
                ;

            Mapper.CreateMap<Ent.NotificationDetail, RetModels.StudentNotification>()
                .ForMember(x => x.Links, opt => opt.Ignore())
                .ForMember(d => d.NotificationId, x => x.MapFrom(s => s.Notification.NotificationId))
                .ForMember(d => d.Text, x => x.MapFrom(s => s.Notification.Text))
                .ForMember(d => d.GroupId, x => x.MapFrom(s => s.Notification.GroupId))
                .ForMember(d => d.SchoolUserId, x => x.MapFrom(s => s.Notification.SchoolUserId))
                .ForMember(d => d.Name, x => x.MapFrom(s => s.Student.Name))
                .ForMember(d => d.StudentId, x => x.MapFrom(s => s.Student.StudentId))
                .ForMember(d => d.Curp, x => x.MapFrom(s => s.Student.Curp))
                ;
        }
    }
}
