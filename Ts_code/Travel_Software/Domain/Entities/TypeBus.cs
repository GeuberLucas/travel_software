using Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class TypeBus:BaseClass
    {
        public string Description { get; private set; }
        public int QuantityArmchairs { get; private set; }

        public TypeBus(string description, int quantityArmchairs, DateTime createdAt, DateTime updateAt)
        {
            ValidateDomain(description, quantityArmchairs);
            ValidateBaseClass(createdAt, updateAt);
            
        }

        private void ValidateDomain(string description, int quantityArmchairs)
        {
            DomainExceptionValidation.When(String.IsNullOrEmpty(description), "Tipo_Onibus.Descricao inválido. A Descricao é requirido");
            DomainExceptionValidation.When(description.Length < 3, "Tipo_Onibus.Descricao inválido. A Descricao deve conter pelo menos 3 caracteres");
            DomainExceptionValidation.When(description.Length > 250, "Tipo_Onibus.Descricao inválido. A Descricao deve conter no máximo 250 caracteres");

            DomainExceptionValidation.When(quantityArmchairs < 0, "Tipo_Onibus.Quantidade_Poltronas inválida. A Quantidade Poltronas é requirido");

            Description = description;
            QuantityArmchairs = quantityArmchairs;

        }
    }
}
