using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validation
{
    public class DomainExceptionValidation: Exception
    {
        public DomainExceptionValidation(string error) :base(error)
        {
            
        }

        public static void When(bool hasError,string error)
        {
            if (hasError)
            {
                throw new DomainExceptionValidation(error);
            }
        }
    }
    //ao invés de escrever as validações (if/else) na entidade,foi criada esta classe para receber a condição e lançar uma Exception 

}
