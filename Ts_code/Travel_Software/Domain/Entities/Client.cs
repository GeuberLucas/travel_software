using Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Client
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime BirthDay { get; set; }
        public string Contact { get; set; }
        public string IssuingAgency { get; set; }//orgão emissor
        public string IssuingState { get; set; }//estado emissor
        public string? UrlDocument { get; set; }


        public Client(string name, string cpf, string rg, DateTime birthDay, string contact, string issuingAgency, string issuingState, string urlDocument)
        {

            ValidateDomain( name,  cpf,  rg,  birthDay,  contact,  issuingAgency,  issuingState,  urlDocument)
        }

        public Client(int id, DateTime createdAt, DateTime updateAt, string name, string cpf, string rg, DateTime birthDay, string contact, string issuingAgency, string issuingState, string urlDocument)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdateAt = updateAt;
            Name = name;
            CPF = cpf;
            RG = rg;
            BirthDay = birthDay;
            Contact = contact;
            IssuingAgency = issuingAgency;
            IssuingState = issuingState;
            UrlDocument = urlDocument;
        }



        public ICollection<Trip> Trips { get; set; }

        private void ValidateDomain(string name, string cpf, string rg, DateTime birthDay, string contact, string issuingAgency, string issuingState, string? urlDocument)
        {
            DomainExceptionValidation.When(String.IsNullOrEmpty(name), "Nome inválido. O nome é requirido");
            DomainExceptionValidation.When(name.Trim().Split(" ").Length < 2, "Nome inválido. O Nome deve conter ao menos 1 Sobrenome ");
            DomainExceptionValidation.When(String.IsNullOrEmpty(cpf), "CPF inválido. O CPF é requirido");
            DomainExceptionValidation.When(ValidateCpf(cpf), "CPF inválido. O CPF não é valido de acordo com requisitos federais");
            DomainExceptionValidation.When(String.IsNullOrEmpty(rg), "RG inválido. O RG é requirido");
            DomainExceptionValidation.When(birthDay == DateTime.MinValue, "Data de Nascimento inválida. A Data de Nascimento é requirido");
            DomainExceptionValidation.When(birthDay > DateTime.Now, "Data de Nascimento inválida. A Data de Nascimento não pode ser posterior á atual");
            DomainExceptionValidation.When(String.IsNullOrEmpty(contact), "Telefone inválido. O Telefone é requirido");
            DomainExceptionValidation.When(contact.Length != 11, "Telefone inválido. O Telefone é deve conter o DDD e os 9 digítos");
            DomainExceptionValidation.When(String.IsNullOrEmpty(issuingAgency), "Orgão Emissor inválido. O Orgão Emissor é requirido");
            DomainExceptionValidation.When(String.IsNullOrEmpty(issuingState), "Uf Emissor inválido. A Uf Emissor é requirido");
            
            Name = name;
            CPF = cpf;
            RG = rg;
            BirthDay = birthDay;
            Contact = contact;
            IssuingAgency = issuingAgency;
            IssuingState = issuingState;
            UrlDocument = urlDocument;

        }

        private bool ValidateCpf(string cpf)
        {
            if (cpf.Length != 11)
                return false;

            if (cpf.Distinct().Count() == 1 || cpf == "12345678909")
                return false;

            for (int j = 0; j < 2; j++)
            {
                int sum = 0;
                for (int i = 0; i < 9 + j; i++)
                {
                    sum += (10 + j - i) * int.Parse(cpf[i].ToString());
                }

                int remainder = sum % 11;
                if (remainder < 2)
                {
                    if (cpf[9 + j] != '0')
                        return false;
                }
                else
                {
                    if (cpf[9 + j] != (11 - remainder).ToString()[0])
                        return false;
                }
            }

            return true;

        }
    }
}
