﻿using AutoMapper;
using Edutor.Common.TypeMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using New = Edutor.Web.Api.Models.NewModels;
using Return = Edutor.Web.Api.Models.ReturnTypes;
using Modifiable = Edutor.Web.Api.Models.ModModels;
using Ent = Edutor.Data.Entities;

namespace Edutor.Web.Api.AutoMappingConfigurator
{
    public class NewSchoolUserToUserEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<New.NewSchoolUser, Ent.User>()
                .ForMember(o => o.UserId, opt => opt.Ignore())
                .ForMember(o => o.Type, opt => opt.UseValue(Ent.User.SchoolUserType))
                .ForMember(o => o.Job, opt => opt.Ignore())
                .ForMember(o => o.JobTelephone, opt => opt.Ignore())
                .ForMember(o => o.Version, x => x.Ignore())
                .ForMember(s => s.Groups, x => x.Ignore())
                .ForMember(s => s.Students, x => x.Ignore())
                .ForMember(s => s.Password, x => x.Ignore())
                ;


            Mapper.CreateMap<Ent.User, Return.SchoolUser>()
                .ForMember(x => x.Links, opt => opt.Ignore())
                .ForMember(x => x.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(x => x.UserId, opt => opt.MapFrom(s => s.UserId))
                ;

            Mapper.CreateMap<Ent.TeacherForStudent, Return.SchoolUser>()
                .ForMember(x => x.Links, opt => opt.Ignore())
                .ForMember(x => x.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(x => x.UserId, opt => opt.MapFrom(s => s.UserId))
                ;


            Mapper.CreateMap<Modifiable.ModifiableSchoolUser, Ent.User>()
                //.ForMember(o => o.UserId, opt => opt.Ignore())
               .ForMember(o => o.Curp, x => x.Ignore())
                .ForMember(o => o.Type, opt => opt.UseValue(Ent.User.SchoolUserType))
                .ForMember(o => o.Job, opt => opt.Ignore())
                .ForMember(o => o.JobTelephone, opt => opt.Ignore())
                .ForMember(o => o.Version, x => x.Ignore())
                .ForMember(s => s.Groups, x => x.Ignore())
                .ForMember(s => s.Students, x => x.Ignore())
                .ForMember(s => s.Password, x => x.Ignore())
                ;
        }
    }
}
