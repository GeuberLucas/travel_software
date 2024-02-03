
using Domain.Entities;
using Domain.Validation;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.Domain
{
    public class ClientUnitTest
    {
        [Fact]
        public void CreateClient_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Client("Geuber Lucas", "50441606016", "20023424", new DateTime(2006, 2, 2), "31995244597", "SSP", "MG", "",DateTime.Now, DateTime.Now);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateClient_WithNameEmpty_ThrowExceptionNameRequired()
        {
            Action action = () => new Client("", "50441606016", "20023424", new DateTime(2006, 2, 2), "31995244597", "SSP", "MG", "",DateTime.Now, DateTime.Now);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Nome inválido. O nome é requirido");
        }
        [Fact]
        public void CreateClient_WithOnlyFirstName_ThrowExceptionNameInvalid()
        {
            Action action = () => new Client("Geuber", "50441606016", "20023424", new DateTime(2006, 2, 2), "31995244597", "SSP", "MG", "",DateTime.Now, DateTime.Now);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Nome inválido. O Nome deve conter ao menos 1 Sobrenome");
        }
        
        [Fact]
        public void CreateClient_WithCPFEmpty_ThrowExceptionCpfRequired()
        {
            Action action = () => new Client("Geuber Lucas", "", "20023424", new DateTime(2006, 2, 2), "31995244597", "SSP", "MG", "",DateTime.Now, DateTime.Now);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("CPF inválido. O CPF é requirido");
        }
        [Fact]
        public void CreateClient_WithCPFInvalid_ThrowExceptionCPFInvalid()
        {
            Action action = () => new Client("Geuber Lucas", "50441606017", "20023424", new DateTime(2006, 2, 2), "31995244597", "SSP", "MG", "",DateTime.Now, DateTime.Now);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("CPF inválido. O CPF não é valido de acordo com requisitos federais");
        }

        [Fact]
        public void CreateClient_WithDocumentEmpty_ThrowExceptionDocumentRequired()
        {
            Action action = () => new Client("Geuber Lucas", "50441606016", "", new DateTime(2006, 2, 2), "31995244597", "SSP", "MG", "", DateTime.Now, DateTime.Now);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("RG inválido. O RG é requirido");
        }

        [Fact]
        public void CreateClient_WithBirthDayMinValue_ThrowExceptionBirthDayRequired()
        {
            Action action = () => new Client("Geuber Lucas", "50441606016", "20023424", DateTime.MinValue, "31995244597", "SSP", "MG", "", DateTime.Now, DateTime.Now);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Data de Nascimento inválida. A Data de Nascimento é requirido");
        }

        [Fact]
        public void CreateClient_WithBirthDayLater_ThrowExceptionBirthDayInvalid()
        {
            Action action = () => new Client("Geuber Lucas", "50441606016", "20023424", DateTime.Now.AddDays(1), "31995244597", "SSP", "MG", "", DateTime.Now, DateTime.Now);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Data de Nascimento inválida. A Data de Nascimento não pode ser posterior á atual");
        }

        [Fact]
        public void CreateClient_WithContactEmpty_ThrowExceptionContactRequired()
        {
            Action action = () => new Client("Geuber Lucas", "50441606016", "20023424", DateTime.Now, "", "SSP", "MG", "", DateTime.Now, DateTime.Now);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Telefone inválido. O Telefone é requirido");
        }
        [Fact]
        public void CreateClient_WithContactInvalid_ThrowExceptionContactInvalid()
        {
            Action action = () => new Client("Geuber Lucas", "50441606016", "20023424", DateTime.Now, "31999", "SSP", "MG", "", DateTime.Now, DateTime.Now);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Telefone inválido. O Telefone é deve conter o DDD e os 9 digítos");
        }
        [Fact]
        public void CreateClient_WithIssuingAgencyEmpty_ThrowExceptionIssuingAgency()
        {
            Action action = () => new Client("Geuber Lucas", "50441606016", "20023424", DateTime.Now, "31995244597", "", "MG", "", DateTime.Now, DateTime.Now);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Orgão Emissor inválido. O Orgão Emissor é requirido");
        }
        [Fact]
        public void CreateClient_WithIssuingStateEmpty_ThrowExceptionIssuingState()
        {
            Action action = () => new Client("Geuber Lucas", "50441606016", "20023424", DateTime.Now, "31995244597", "SSp", "", "", DateTime.Now, DateTime.Now);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Uf Emissor inválido. A Uf Emissor é requirido");
        }
        [Fact]
        public void CreateClient_WithUrlDocumentBig_ThrowExceptionUrlDocument()
        {
            Action action = () => new Client("Geuber Lucas", "50441606016", "20023424", DateTime.Now, "31995244597", "SSp", "MG", "https://www.example.com/3j4h5g6k7l8m9n0p1q2w3e4r5t6y7u8i9o0p1a2s3d4f5g6h7j8k9l0z1x2c3v4b5n6m7q8w9e0r1t2y3u4i5o6p7a8s9d0f1g2h3j4k5l6z7x8c9v0b1n2m3q4w5e6r7t8y9u0i1o2p3a4s5d6f7g8h9j0k1l2z3x4c5v6b7n8m9q1w2e3r4t5y6u7i8o9p0a1s2d3f4g5h6j7k8l9z0x1c2v3b4n5m6\r\n", DateTime.Now, DateTime.Now);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("A Url do documento é maior que o permitido, máximo de 250 caracteres");
        }
    }

}
