using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edutor.Data.Entities;

namespace Edutor.Data.QueryProcessors
{
    public interface IAddConversationQueryProcessor
    {
        void AddNewMessage(Message msg);
    }
}
