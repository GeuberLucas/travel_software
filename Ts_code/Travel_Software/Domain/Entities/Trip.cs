using Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class Trip : BaseClass
    {
        

        public string Title { get;private set; }
        public string DestinationCity { get;private set; }
        public string DestinationState { get;private set; }
        public string DepartureCity { get;private set; }
        public string DepartureState { get;private set; }
        public DateTime Departure { get;private set; }
        public DateTime ReturnTime { get;private set; }
        public decimal ValueTicket { get;private set; }

        public Trip(string title, string destinationCity, string destinationState, string departureCity, string departureState, DateTime departure, DateTime returnTime, decimal valueTicket, DateTime createdAt, DateTime updateAt)
        {
            ValidateBaseClass(createdAt, updateAt);
            ValidateDomain(title, destinationCity, destinationState, departureCity, departureState, departure, returnTime, valueTicket);
        }

        private void ValidateDomain(string title, string destinationCity, string destinationState, string departureCity, string departureState, DateTime departure, DateTime returnTime, decimal valueTicket)
        {
            //VALIDAÇÃO DE NUL0 OU VAZIO
            DomainExceptionValidation.When(String.IsNullOrEmpty(title), "Viagem.Titulo inválido. O titulo é requirido");
            DomainExceptionValidation.When(String.IsNullOrEmpty(destinationCity), "Viagem.Cidade_Destino inválido. A Cidade Destino é requirido");
            DomainExceptionValidation.When(String.IsNullOrEmpty(destinationState), "Viagem.Estado_Destino inválido. O Estado Destino é requirido");
            DomainExceptionValidation.When(String.IsNullOrEmpty(departureCity), "Viagem.Cidade_Partida inválido. A Cidade Partida é requirido");
            DomainExceptionValidation.When(String.IsNullOrEmpty(departureState), "Viagem.Estado_Destino inválido. A Estado Destino é requirido");
            
            //VALIDAÇÃO DE TAMANHO MINIMO
            DomainExceptionValidation.When(title.Length<3, "Viagem.Titulo inválido. O titulo deve conter pelo menos 3 caracteres");
            DomainExceptionValidation.When(destinationCity.Length<3, "Viagem.Cidade_Destino inválido. A Cidade Destino deve conter pelo menos 3 caracteres");
            DomainExceptionValidation.When(destinationState.Length<3, "Viagem.Estado_Destino inválido. A Estado Destino deve conter pelo menos 3 caracteres");
            DomainExceptionValidation.When(departureCity.Length<3, "Viagem.Cidade_Partida inválido. A Cidade Partida deve conter pelo menos 3 caracteres");
            DomainExceptionValidation.When(departureState.Length<3, "Viagem.Estado_Destino inválido. A Estado Destino deve conter pelo menos 3 caracteres");

            //VALIDAÇÃO DE TAMANHO MÁXIMO
            DomainExceptionValidation.When(title.Length>250, "Viagem.Titulo inválido. O titulo deve conter no máximo 250 caracteres");
            DomainExceptionValidation.When(destinationCity.Length>250, "Viagem.Cidade_Destino inválido. A Cidade Destino deve conter no máximo 250 caracteres");
            DomainExceptionValidation.When(destinationState.Length>250, "Viagem.Estado_Destino inválido. A Estado Destino deve conter no máximo 250 caracteres");
            DomainExceptionValidation.When(departureCity.Length>250, "Viagem.Cidade_Partida inválido. A Cidade Partida deve conter no máximo 250 caracteres");
            DomainExceptionValidation.When(departureState.Length>250, "Viagem.Estado_Destino inválido. A Estado Destino deve conter no máximo 250 caracteres");

            DomainExceptionValidation.When(departure == DateTime.MinValue, "Viagem.Data_Partida inválida. A Data de Partida é requirido");
            DomainExceptionValidation.When(returnTime == DateTime.MinValue, "Viagem.Data_Retorno inválida. A Data Retorno é requirido");
            DomainExceptionValidation.When(departure > returnTime, "Viagem.Data_Partida inválida. A Data de Partida não pode ser posterior a Data Retorno");

            DomainExceptionValidation.When(valueTicket < 0, "Viagem.Valor_Passagem inválida. O Valor Passagem é requirido");

            Title = title;
            DestinationCity = destinationCity;
            DestinationState = destinationState;
            DepartureCity = departureCity;
            DepartureState = departureState;
            Departure = departure;
            ReturnTime = returnTime;
            ValueTicket = valueTicket;

        }
    }
}
