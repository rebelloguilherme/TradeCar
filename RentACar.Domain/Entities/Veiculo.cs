using RentACar.Domain.Validation;
using System;

namespace RentACar.Domain.Entities
{
    public sealed class Veiculo : Entity
    {
        public Proprietario Proprietario { get; set; }
        public Guid ProprietarioId { get; set; }
        public Marca Marca { get; set; }
        public Guid MarcaId { get; set; }
        public string Renavam { get; private set; }
        public string Modelo { get; private set; }
        public DateTime AnoFabricacao { get; private set; }
        public DateTime AnoModelo { get; private set; }
        public int Quilometragem { get; private set; }
        public decimal Valor { get; private set; }
        public StatusVeiculo StatusVeiculo { get; private set; }

        private Veiculo()
        {

        }
        public Veiculo(Proprietario proprietario, string renavam, Marca marca, string modelo, DateTime anoFabricacao, DateTime anoModelo, int quilometragem, decimal valor, StatusVeiculo statusVeiculo)
        {
            ValidateDomain(proprietario, renavam, marca, modelo, anoFabricacao, anoModelo, quilometragem, valor, statusVeiculo);
        }

        public Veiculo(Guid id, Proprietario proprietario, string renavam, Marca marca, string modelo, DateTime anoFabricacao, DateTime anoModelo, int quilometragem, decimal valor, StatusVeiculo statusVeiculo)
        {
            DomainExceptionValidation.When(id == Guid.Empty || id == null, "Id inválido.");
            Id = id;
            ValidateDomain(proprietario, renavam, marca, modelo, anoFabricacao, anoModelo, quilometragem, valor, statusVeiculo);
        }

        private void ValidateDomain(Proprietario proprietario, string renavam, Marca marca, string modelo, DateTime anoFabricacao, DateTime anoModelo, int quilometragem, decimal valor, StatusVeiculo statusVeiculo)
        {
            DomainExceptionValidation.When(proprietario == null, "Proprietário não pode ser nulo");
            DomainExceptionValidation.When(string.IsNullOrEmpty(renavam), "Renavam não pode ser nulo ou em branco");
            DomainExceptionValidation.When(marca == null, "Marca não pode ser nula");
            DomainExceptionValidation.When(string.IsNullOrEmpty(modelo), "Modelo não pode ser nulo ou em branco");
            DomainExceptionValidation.When(anoFabricacao.Year == 0, "Ano de fabricação não pode estar em branco");
            DomainExceptionValidation.When(anoFabricacao.Year > DateTime.Now.Year, "Ano de fabricação não pode ser maior que o ano atual");
            DomainExceptionValidation.When(anoModelo.Year == 0, "Ano de fabricação não pode estar em branco");
            DomainExceptionValidation.When(valor <= 0, "Valor não pode ser menor ou igual a zero");

            Proprietario = proprietario;
            Renavam = renavam;
            Marca = marca;
            Modelo = modelo;
            AnoFabricacao = anoFabricacao;
            AnoModelo = anoModelo;
            Quilometragem = quilometragem;
            Valor = valor;
            StatusVeiculo = statusVeiculo;
        }
    }
}
