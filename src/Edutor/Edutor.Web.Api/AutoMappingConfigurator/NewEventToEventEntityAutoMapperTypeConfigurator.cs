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
    public class NewEventToEventEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<NwModels.NewEvent, Ent.Event>()
                .ForMember(o => o.EventId, opt => opt.Ignore())
                .ForMember(o => o.CreationDate, opt => opt.Ignore())
                .ForMember(o => o.SchoolUser, opt => opt.Ignore())
                .ForMember(o => o.Version, x => x.Ignore())
                .ForMember(o => o.Invitations, x => x.Ignore())
                .ForMember(o => o.Group, x => x.Ignore())
                ;


            Mapper.CreateMap<Ent.Event, RetModels.Event>()
                .ForMember(x => x.Links, opt => opt.Ignore())
                .ForMember(x => x.SchoolUserId, opt => opt.MapFrom(src => src.SchoolUser.UserId))
                ;

            Mapper.CreateMap<Ent.Invitation, RetModels.StudentInvitation>()
                .ForMember(x => x.Links, opt => opt.Ignore())
                .ForMember(d => d.EventName, x => x.MapFrom(s => s.Event.Name))
                .ForMember(d => d.EventId, x => x.MapFrom(s => s.Event.EventId))
                .ForMember(d => d.Description, x => x.MapFrom(s => s.Event.Description))
                .ForMember(d => d.GroupId, x => x.MapFrom(s => s.Event.GroupId))
                .ForMember(d => d.SchoolUserId, x => x.MapFrom(s => s.Event.SchoolUserId))
                .ForMember(d => d.StudentId, x => x.MapFrom(s => s.Student.StudentId))
                .ForMember(d => d.Name, x => x.MapFrom(s => s.Student.Name))
                .ForMember(d => d.Curp, x => x.MapFrom(s => s.Student.Curp))
                ;

            Mapper.CreateMap<NwModels.NewRsvp, Ent.Invitation>()
                .ForMember(o => o.Rsvp, opt => opt.MapFrom(s => s.Rsvp))
                .ForMember(o => o.Event, x => x.Ignore())
                .ForMember(o => o.Student, x => x.Ignore())
                .ForMember(o => o.Version, x => x.Ignore())
                ;
        }
    }
}

