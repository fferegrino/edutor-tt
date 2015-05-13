using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.QueryProcessors
{
    public interface IAddAnswerQueryProcessor
    {
        void AddAnswer(Data.Entities.Answer a);

        void AddAnswers(IList<Data.Entities.Answer> aS);
    }
}
