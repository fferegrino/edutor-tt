﻿using AutoMapper;
using Edutor.Common.TypeMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NwModels = Edutor.Web.Api.Models.NewModels;

namespace Edutor.Web.Api.AutoMappingConfigurator
{
    public class NewSchoolUserToUserEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<NwModels.NewSchoolUser, Data.Entities.User>()
                .ForMember(o => o.UserId, opt => opt.Ignore())
                .ForMember(o => o.Job, opt => opt.Ignore())
                .ForMember(o => o.JobTelephone, opt => opt.Ignore())
                .ForMember(o => o.Version, x => x.Ignore())
                //.ForMember(o => o.SchoolUserId, x => x.Ignore())
                //.ForMember(o => o.User, x => x.Ignore())
                //.ForMember(o => o.Version, x => x.Ignore())
                ;
        }
    }

    public class UserEntityToNewSchoolUserAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Data.Entities.User,NwModels.NewSchoolUser>()
                .ForMember(x=> x.Links, opt=> opt.Ignore())
                //.ForMember(o => o.UserId, opt => opt.Ignore()
                //.ForMember(o => o.Job, opt => opt.Ignore())
                //.ForMember(o => o.JobTelephone, opt => opt.Ignore())
                //.ForMember(o => o.Version, x => x.Ignore())
                //.ForMember(o => o.SchoolUserId, x => x.Ignore())
                //.ForMember(o => o.User, x => x.Ignore())
                //.ForMember(o => o.Version, x => x.Ignore())
                ;
        }
    }
}
