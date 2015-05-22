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
    public class NewGroupToGroupEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<NwModels.NewGroup, Ent.Group>()
                .ForMember(o => o.GroupId, opt => opt.Ignore())
                .ForMember(o => o.Version, x => x.Ignore())
                .ForMember(s => s.Students, x => x.Ignore())
                .ForMember(s => s.Teachers, x => x.Ignore())
                ;

            Mapper.CreateMap<Ent.Group, RetModels.Group>()
                .ForMember(x => x.Links, opt => opt.Ignore())
                ;
        }
    }
}
