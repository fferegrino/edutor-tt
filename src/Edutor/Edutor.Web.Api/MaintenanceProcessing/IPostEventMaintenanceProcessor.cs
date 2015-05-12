using Edutor.Common.TypeMapping;
using Edutor.Data.QueryProcessors;
using Edutor.Web.Api.LinkServices;
using Edutor.Web.Api.Models.NewModels;
using Ret = Edutor.Web.Api.Models.ReturnTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.MaintenanceProcessing
{
    public interface IPostEventMaintenanceProcessor
    {
        Ret.Event AddEvent(NewEvent ev);
    }

    public class PostEventMaintenanceProcessor : IPostEventMaintenanceProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IAddEventQueryProcessor _addUserQueryProcessor;
        private readonly IEventsLinkService _linkServices;

        public PostEventMaintenanceProcessor(IAutoMapper autoMapper, IAddEventQueryProcessor addUserQueryProcessor, IEventsLinkService linkServices)
        {
            _autoMapper = autoMapper;
            _addUserQueryProcessor = addUserQueryProcessor;
            _linkServices = linkServices;
        }


        public Ret.Event AddEvent(NewEvent ev)
        {

            var userEntity = _autoMapper.Map<Data.Entities.Event>(ev);
            _addUserQueryProcessor.AddEvent(userEntity);
            var ret = _autoMapper.Map<Ret.Event>(userEntity);

            // TODO Implement link service here
            _linkServices.AddSelfLink(ret);

            return ret;
        }
    }
}
