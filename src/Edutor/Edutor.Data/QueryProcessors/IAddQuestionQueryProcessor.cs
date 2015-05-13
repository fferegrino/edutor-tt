using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.QueryProcessors
{
    public interface IAddQuestionQueryProcessor
    {
        void AddQuestion(Data.Entities.Question q);
    }
}
