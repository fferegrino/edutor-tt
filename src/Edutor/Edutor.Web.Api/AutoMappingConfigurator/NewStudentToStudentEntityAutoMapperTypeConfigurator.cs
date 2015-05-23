﻿using AutoMapper;
using Edutor.Common.TypeMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NwModels = Edutor.Web.Api.Models.NewModels;
using RetModels = Edutor.Web.Api.Models.ReturnTypes;
using Modifiable = Edutor.Web.Api.Models.ModModels;
using Ent = Edutor.Data.Entities;

namespace Edutor.Web.Api.AutoMappingConfigurator
{
    public class NewStudentToStudentEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<NwModels.NewStudent, Ent.Student>()
                .ForMember(o => o.StudentId, opt => opt.Ignore())
                .ForMember(o => o.Token, opt => opt.Ignore())
                .ForMember(o => o.Tutor, opt => opt.Ignore())
                .ForMember(o => o.IsActive, opt => opt.Ignore())
                .ForMember(o => o.Version, x => x.Ignore())
                .ForMember(s => s.Groups, x => x.Ignore())
                ;


            Mapper.CreateMap<Ent.Student, RetModels.Student>()
                .ForMember(x => x.Links, opt => opt.Ignore())
                 .ForMember(x => x.TutorId, opt => opt.MapFrom(src => src.Tutor.UserId))
                ;

            Mapper.CreateMap<Modifiable.ModifiableStudent, Ent.Student>()
               //.ForMember(o => o.StudentId, opt => opt.Ignore())
               .ForMember(o => o.TutorId, opt => opt.Ignore())
               .ForMember(o => o.Token, opt => opt.Ignore())
               .ForMember(o => o.Curp, x => x.Ignore())
               .ForMember(o => o.Tutor, opt => opt.Ignore())
               .ForMember(o => o.IsActive, opt => opt.Ignore())
               .ForMember(o => o.Version, x => x.Ignore())
               .ForMember(s => s.Groups, x => x.Ignore())
               ;
        }
    }

}
