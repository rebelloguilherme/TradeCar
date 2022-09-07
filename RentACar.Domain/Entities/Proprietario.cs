using RentACar.Domain.Validation;
using System;
using System.Collections.Generic;

namespace RentACar.Domain.Entities
{
    public sealed class Proprietario : Entity
    {
        public string Nome { get; private set; }
        public StatusCadastro Status { get; private set; }
        public string Documento { get; private set; }
        public string Email { get; private set; }
        public Endereco Endereco { get; private set; }
        public ICollection<Veiculo> Veiculos { get; set; }

        private Proprietario()
        {

        }
        public Proprietario(string nome, StatusCadastro status, string documento, string email)
        {
            ValidateDomain(nome, status, documento, email);
        }


        private void ValidateDomain(string nome, StatusCadastro status, string documento, string email)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Proprietário não pode ser nulo ou em branco");
            DomainExceptionValidation.When(string.IsNullOrEmpty(documento), "Documento não pode ser nulo ou em branco");
            DomainExceptionValidation.When(string.IsNullOrEmpty(email), "Email não pode ser nulo ou em branco");

            Nome = nome;
            Status = status;
            Documento = documento;
            Email = email;
        }
    }
}
