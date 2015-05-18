using Edutor.Common.TypeMapping;
using Edutor.Data.Entities;
using Edutor.Data.QueryProcessors;
using Edutor.Web.Api.Models.NewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.UpdateProcessing
{
    public interface IPutEventsUpdateProcessor
    {
        void Rsvp(NewRsvp newRsvp);
    }

    public class PutEventsUpdateProcessor : IPutEventsUpdateProcessor
    {
        private readonly IAutoMapper _mapper;
        private readonly IUpdateEventsQueryProcessor _updateEvents;

        public PutEventsUpdateProcessor(IUpdateEventsQueryProcessor updateEvents,
            IAutoMapper mapper)
        {
            _updateEvents = updateEvents;
            _mapper = mapper;
        }

        public void Rsvp(NewRsvp newRsvp)
        {
            _updateEvents.Rsvp(_mapper.Map<Invitation>(newRsvp));
        }
    }
}
