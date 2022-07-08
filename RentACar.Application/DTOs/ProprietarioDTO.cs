using RentACar.Domain.Entities;
using System.Collections.Generic;

namespace RentACar.Application.DTOs
{
    public class ProprietarioDTO
    {
        public string Nome { get; private set; }
        public StatusCadastro Status { get; private set; }
        public string Documento { get; private set; }
        public string Email { get; private set; }
        public string Endereco { get; private set; }
        public ICollection<Veiculo> Veiculos { get; set; }
    }
}
