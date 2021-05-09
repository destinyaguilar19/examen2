using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DymaDieckBackend.exceptions
{
    public class BusinessRuleValidationException : Exception
    {
        public BusinessRuleValidationException()
        {
        }

        public BusinessRuleValidationException(string message)
        : base(message)
        {
        }

        public BusinessRuleValidationException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
