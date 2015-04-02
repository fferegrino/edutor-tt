using AutoMapper;
using Edutor.Common.TypeMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models = Edutor.Web.Api.Models;

namespace Edutor.Web.Api.AutoMappingConfigurator
{
    public class SchoolUserEntityToSimpleSchoolUserModelAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {

            
            Mapper.CreateMap<Data.Entities.SchoolUser, Models.SimpleSchoolUser>()
                .ForMember(o => o.Links, x => x.Ignore())
                .ForMember(o => o.Name, o => o.MapFrom(s => s.User.Name))
                .ForMember(x => x.Address, opt => opt.MapFrom(src => src.User.Address))
                .ForMember(x => x.Mobile, opt => opt.MapFrom(src => src.User.Mobile))
                .ForMember(x => x.Phone, opt => opt.MapFrom(src => src.User.Phone))
                .ForMember(x => x.Curp, opt => opt.MapFrom(src => src.User.Curp))
                .ForMember(x => x.Email, opt => opt.MapFrom(src => src.User.Email))
                ;
        }

    }
}