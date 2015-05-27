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



            Func<Ent.Question, object> resolvePossobleAnswers = (ob) =>
            {
                var possobleAnswers = new List<RetModels.PossibleAnswer>();
                if (ob.PossibleAnswers != null)
                {
                    foreach (var pa in ob.PossibleAnswers)
                    {
                        var rrr = Mapper.Map<RetModels.PossibleAnswer>(pa);
                        rrr.QuestionId = ob.QuestionId;
                        possobleAnswers.Add(rrr);
                    }
                }
                return possobleAnswers;
            };

            Mapper.CreateMap<Ent.Question, RetModels.Question>()
                .ForMember(x => x.Links, opt => opt.Ignore())
                .ForMember(s => s.PossibleAnswers, x => x.ResolveUsing(resolvePossobleAnswers))
                 .ForMember(x => x.SchoolUserId, opt => opt.MapFrom(src => src.SchoolUser.UserId))
                ;

            Func<Ent.Answer, object> resolveActualAns = (ob) =>
            {
                if (ob.ActualAnswer == null)
                    return null;
                else
                    return ob.ActualAnswer.Text;
            };

            Func<Ent.Answer, object> resolveActualAnsId = (ob) =>
            {
                if (ob.ActualAnswer == null)
                    return 0;
                else
                    return ob.ActualAnswerId;
            };

            Mapper.CreateMap<Ent.Answer, RetModels.StudentAnswer>()
                .ForMember(x => x.Links, opt => opt.Ignore())
                .ForMember(d => d.Text, x => x.MapFrom(s => s.Question.Text))
                .ForMember(d => d.QuestionId, x => x.MapFrom(s => s.Question.QuestionId))
                .ForMember(d => d.GroupId, x => x.MapFrom(s => s.Question.GroupId))
                .ForMember(d => d.SchoolUserId, x => x.MapFrom(s => s.Question.SchoolUserId))
                .ForMember(d => d.AnswerId, x => x.ResolveUsing(resolveActualAnsId))
                .ForMember(d => d.AnswerText, x => x.ResolveUsing(resolveActualAns))
                .ForMember(d => d.StudentId, x => x.MapFrom(s => s.Student.StudentId))
                .ForMember(d => d.Name, x => x.MapFrom(s => s.Student.Name))
                .ForMember(d => d.Curp, x => x.MapFrom(s => s.Student.Curp))
                ;

            Mapper.CreateMap<Ent.PossibleAnswer, RetModels.PossibleAnswer>()
                .ForMember(x => x.Links, opt => opt.Ignore())
                ;


            Mapper.CreateMap<NwModels.NewAnswer, Ent.Answer>()
                .ForMember(o => o.ActualAnswerId, x => x.MapFrom(xx => xx.SelectedAnswerId))
                .ForMember(o => o.AnswerDate, x => x.Ignore())
                .ForMember(o => o.ActualAnswer, x => x.Ignore())
                .ForMember(o => o.Question, x => x.Ignore())
                .ForMember(o => o.Student, x => x.Ignore())
                .ForMember(o => o.Version, x => x.Ignore())
                ;
        }
    }
}
