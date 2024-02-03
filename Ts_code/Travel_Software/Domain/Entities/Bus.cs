using Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace Domain.Entities
{
    public sealed class Bus:BaseClass
    {
        public int Number { get; private set; }
        public int IdType { get; private set; }
        public string Company { get; private set; }

        public Bus(int number, int idType, string company, DateTime createdAt, DateTime updateAt)
        {
            ValidateDomain(number, idType, company);
            ValidateBaseClass(createdAt, updateAt);
        }

        private void ValidateDomain(int number, int idType, string company)
        {
            DomainExceptionValidation.When(String.IsNullOrEmpty(company), "Empresa inválida.A Empresa é requirida");
            DomainExceptionValidation.When(company.Length < 3, "Empresa inválida. A Empresa deve conter ao menos 3 caracteres");
            DomainExceptionValidation.When(number < 0, "Número do ônibus inválida. Número do ônibus deve um numero positivo");
            DomainExceptionValidation.When(idType <= 0, "Tipo do ônibus inválido. Tipo do ônibus é requirido");
            
            Number = number;
            IdType = idType;
            Company = company;
        }

    }
}
