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
    public class NewUserToSchoolUserEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<NwModels.NewSchoolUser, Data.Entities.SchoolUser>()
                .ForMember(o => o.SchoolUserId, x => x.Ignore())
                .ForMember(o => o.User, x => x.Ignore())
                .ForMember(o => o.Version, x => x.Ignore());
        }
    }
}
