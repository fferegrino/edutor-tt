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
    public class NewTeachingToTeachingEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<NwModels.NewTeaching, Ent.Teaching>()
                .ForMember(s => s.SchoolUser, x => x.Ignore())
                .ForMember(s => s.Group, x => x.Ignore())
                .ForMember(s => s.Version, x => x.Ignore())
                ;
        }
    }

}
