using Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.Net.Sockets;
using System.Data;

namespace Domain.Entities
{
    public sealed class Ticket:BaseClass
    {
        public int IdClient { get; private set; }
        public int IdBus { get; private set; }
        public int IdTrip { get; private set; }
        public int BusSeat { get; private set; }

        public Ticket(int idClient, int idBus, int idTrip, int busSeat, DateTime createdAt, DateTime updateAt)
        {
            ValidateDomain(idClient, idBus, idTrip, busSeat);
            ValidateBaseClass(createdAt, updateAt);
            
        }

        private void ValidateDomain(int idClient, int idBus, int idTrip, int busSeat)
        {
            DomainExceptionValidation.When(idClient <= 0, "Cliente inválido. Cliente é requirido");
            DomainExceptionValidation.When(idBus <= 0, "Ônibus inválido. Ônibus é requirido");
            DomainExceptionValidation.When(idTrip <= 0, "Viagem inválida. Viagem é requirida");
            DomainExceptionValidation.When(busSeat <= 0, "Poltrona do ônibus inválida. Poltrona do ônibus é requirida");

            IdClient = idClient;
            IdBus = idBus;
            IdTrip = idTrip;
            BusSeat = busSeat;

        }



    }
}
