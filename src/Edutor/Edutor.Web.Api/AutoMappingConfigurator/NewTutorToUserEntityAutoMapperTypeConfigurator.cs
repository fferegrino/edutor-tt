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
    public class NewTutorToUserEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<NwModels.NewTutor, Ent.User>()
                .ForMember(o => o.UserId, opt => opt.Ignore())
                .ForMember(o => o.Type, opt => opt.UseValue(Ent.User.TutorType))
                .ForMember(o => o.Position, opt => opt.Ignore())
                .ForMember(o => o.Version, x => x.Ignore())
                .ForMember(s => s.Groups, x => x.Ignore())
                .ForMember(s => s.Students, x => x.Ignore())
                .ForMember(s => s.Password, x => x.Ignore())
                ;

            
            Mapper.CreateMap<Ent.User, RetModels.Tutor>()
                .ForMember(x => x.Links, opt => opt.Ignore())
                
                .ForMember(x => x.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(x => x.UserId, opt => opt.MapFrom(s => s.UserId))
                ;
        }
    }
}
