using Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class BaseClass
    {
        public int Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdateAt { get; protected set; }

        public void ValidateBaseClass( DateTime createdAt, DateTime updateAt)
        {
            DomainExceptionValidation.When(createdAt > DateTime.Now, "Data de criação inválida. A Data de criação não pode ser posterior a hoje");
            DomainExceptionValidation.When(createdAt == DateTime.MinValue, "Data de criação inválida. A Data de criação é requirida");
            DomainExceptionValidation.When(updateAt > DateTime.Now, "Data de atualização inválida. A Data de atualização não pode ser posterior a hoje");
            DomainExceptionValidation.When(updateAt == DateTime.MinValue, "Data de atualização inválida. A Data de atualização é requirida");
            DomainExceptionValidation.When(updateAt < createdAt, "Data de atualização inválida. A Data de atualização não pode ser anterior a data de criação");
            CreatedAt = createdAt;
            UpdateAt = updateAt;
        }

        public void UpdateAtt(DateTime updateAt)
        {
            DomainExceptionValidation.When(updateAt > DateTime.Now, "Data de atualização inválida. A Data de atualização não pode ser posterior a hoje");
            DomainExceptionValidation.When(updateAt == DateTime.MinValue, "Data de atualização inválida. A Data de atualização é requirida");
            DomainExceptionValidation.When(updateAt < CreatedAt, "Data de atualização inválida. A Data de atualização não pode ser anterior a data de criação");
            UpdateAt = updateAt;
        }
    }
}
