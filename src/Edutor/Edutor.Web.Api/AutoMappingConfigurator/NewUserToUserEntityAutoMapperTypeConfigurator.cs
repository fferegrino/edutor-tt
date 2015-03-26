using AutoMapper;
using Edutor.Common.TypeMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NwModels = Edutor.Web.Api.Models.NewModels;

namespace Edutor.Web.Api.AutoMappingConfigurator
{
    public class NewUserToUserEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<NwModels.NewUser, Data.Entities.User>()
                .ForMember(o => o.UserId, x => x.Ignore())
                .ForMember(o => o.Type, x => x.Ignore())
                .ForMember(o => o.Version, x => x.Ignore());
        }
    }
}
