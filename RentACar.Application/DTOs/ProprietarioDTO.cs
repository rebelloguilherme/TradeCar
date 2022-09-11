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
        public string Nome { get; set; }

        [Required(ErrorMessage = "Necessário informar o Status")]
        public StatusCadastro Status { get; set; }

        [Required(ErrorMessage = "Necessário informar o Documento")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "Necessário informar o Email")]
        public string Email { get; set; }

        public Endereco Endereco { get; set; }
        public ICollection<Veiculo> Veiculos { get; set; }
    }
}
