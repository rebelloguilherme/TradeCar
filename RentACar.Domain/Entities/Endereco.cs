using RentACar.Domain.Validation;
using System;

namespace RentACar.Domain.Entities
{
    public class Endereco: Entity
    {
        public string Uf { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }
        public Proprietario Proprietario { get; set; }
        public Guid ProprietarioId { get; set; }

        public Endereco()
        {

        }
        public Endereco(string uf, string cidade, string bairro, string rua, string numero, string cep, string complemento)
        {
            ValidateDomain(uf, cidade, bairro, rua, numero, cep, complemento);
        }



        private void ValidateDomain(string uf, string cidade, string bairro, string rua, string numero, string cep, string complemento)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(uf), $"{nameof(uf)} não pode ser nulo ou em branco");
            DomainExceptionValidation.When(string.IsNullOrEmpty(cidade), $"{nameof(cidade)} não pode ser nulo ou em branco");
            DomainExceptionValidation.When(string.IsNullOrEmpty(bairro), $"{nameof(bairro)} não pode ser nulo ou em branco");
            DomainExceptionValidation.When(string.IsNullOrEmpty(rua), $"{nameof(rua)} não pode ser nulo ou em branco");
            DomainExceptionValidation.When(string.IsNullOrEmpty(numero), $"{nameof(numero)} não pode ser nulo ou em branco");
            DomainExceptionValidation.When(string.IsNullOrEmpty(cep), $"{nameof(cep)} não pode ser nulo ou em branco");

            Uf = uf;
            Cidade = cidade;
            Bairro = bairro;
            Rua = rua;
            Numero = numero;
            Cep = cep;
            Complemento = complemento;
        }
    }
}
