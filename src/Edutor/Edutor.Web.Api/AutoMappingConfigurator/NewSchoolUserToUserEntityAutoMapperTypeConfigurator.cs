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
    public class NewSchoolUserToUserEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    { 
        public void Configure()
        {
            Mapper.CreateMap<NwModels.NewSchoolUser, Ent.User>()
                .ForMember(o => o.UserId, opt => opt.Ignore())
                .ForMember(o => o.Type, opt => opt.UseValue(Ent.User.SchoolUserType))
                .ForMember(o => o.Job, opt => opt.Ignore())
                .ForMember(o => o.JobTelephone, opt => opt.Ignore())
                .ForMember(o => o.Version, x => x.Ignore())
                ;
        }
    }

    public class UserEntityToNewSchoolUserAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Ent.User,NwModels.NewSchoolUser>()
                .ForMember(x => x.Links, opt => opt.Ignore())
                .ForMember(x => x.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(x => x.UserId, opt => opt.MapFrom(s => s.UserId))
                ;
        }
    }
}
