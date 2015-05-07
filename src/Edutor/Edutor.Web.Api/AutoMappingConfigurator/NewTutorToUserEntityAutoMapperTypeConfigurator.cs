﻿using AutoMapper;
using Edutor.Common.TypeMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NwModels = Edutor.Web.Api.Models.NewModels;
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
                ;
        }
    }

    public class UserEntityToNewTutorAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Ent.User,NwModels.NewTutor>()
                .ForMember(x=> x.Links, opt=> opt.Ignore())
                ;
        }
    }
}
