using RentACar.Domain.Validation;
using System.Collections;
using System.Collections.Generic;

namespace RentACar.Domain.Entities
{
    public sealed class Marca : Entity
    {
        private Marca()
        {

        }
        public Marca(string nome, StatusCadastro status)
        {
            ValidateDomain(nome, status);
        }

        private void ValidateDomain(string nome, StatusCadastro status)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Marca não pode ser nula ou em branco");
            Nome = nome;
            Status = status;
        }

        public ICollection<Veiculo> Veiculos{ get; set; }
        public string Nome { get; private set; }
        public StatusCadastro Status { get; private set; }
    }
}
