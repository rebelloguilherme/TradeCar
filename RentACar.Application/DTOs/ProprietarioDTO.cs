using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentACar.Application.DTOs
{
    public class ProprietarioDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Necessário informar o Nome")]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "Necessário informar o Status")]
        public StatusCadastro Status { get; private set; }

        [Required(ErrorMessage = "Necessário informar o Documento")]
        public string Documento { get; private set; }

        [Required(ErrorMessage = "Necessário informar o Email")]
        public string Email { get; private set; }

        [Required(ErrorMessage = "Necessário informar o Endereço")]
        public string Endereco { get; private set; }
        public ICollection<Veiculo> Veiculos { get; set; }
    }
}
