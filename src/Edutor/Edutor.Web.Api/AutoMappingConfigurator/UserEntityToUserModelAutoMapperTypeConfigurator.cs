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
    public class UserEntityToUserModelAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Data.Entities.User, Models.User>()
                .ForMember(o => o.Links, x => x.Ignore());
        }
    }
}