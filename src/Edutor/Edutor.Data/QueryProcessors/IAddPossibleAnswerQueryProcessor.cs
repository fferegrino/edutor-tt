using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.QueryProcessors
{
    public interface IAddPossibleAnswerQueryProcessor
    {
        void AddPossibleAnswer(Data.Entities.PossibleAnswer p);

        void AddPossibleAnswers(IList<Data.Entities.PossibleAnswer> ps);
    }
}
