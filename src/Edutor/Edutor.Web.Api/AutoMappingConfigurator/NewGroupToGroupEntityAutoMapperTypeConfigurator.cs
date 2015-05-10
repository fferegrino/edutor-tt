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
    public class NewGroupToGroupEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    { 
        public void Configure()
        {
            Mapper.CreateMap<NwModels.NewGroup, Ent.Group>()
                //.ForMember(o => o.GroupId, opt => opt.Ignore())
                .ForMember(o => o.Version, x => x.Ignore())
                ;
        }
    }

    public class GroupEntityToNewGroupAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Ent.Group,NwModels.NewGroup>()
                .ForMember(x => x.Links, opt => opt.Ignore())
                //.ForMember(x => x.GroupId, opt => opt.MapFrom(s => s.Type))
                //.ForMember(x => x.UserId, opt => opt.MapFrom(s => s.UserId))
                ;
        }
    }
}
