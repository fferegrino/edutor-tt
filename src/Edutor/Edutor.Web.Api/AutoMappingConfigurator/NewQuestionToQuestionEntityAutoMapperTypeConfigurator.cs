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
    public class NewQuestionToQuestionEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<NwModels.NewQuestion, Ent.Question>()
                .ForMember(o => o.QuestionId, opt => opt.Ignore())
                .ForMember(o => o.SchoolUser, opt => opt.Ignore())
                .ForMember(o => o.Group, opt => opt.Ignore())
                .ForMember(o => o.Version, x => x.Ignore())
                .ForMember(o => o.Answers, x => x.Ignore())
                .ForMember(o => o.CreationDate, x => x.Ignore())
                .ForMember(o => o.PossibleAnswers, x => x.Ignore())
                .ForMember(s => s.SchoolUser, x => x.Ignore())
                ;

            
            Mapper.CreateMap<Ent.Question, RetModels.Question>()
                .ForMember(x => x.Links, opt => opt.Ignore())
                .ForMember(s => s.PossibleAnswers, x => x.Ignore())
                 .ForMember(x => x.SchoolUserId, opt => opt.MapFrom(src => src.SchoolUser.UserId))
                ;
        }
    }
}
