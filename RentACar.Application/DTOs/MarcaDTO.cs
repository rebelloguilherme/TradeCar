using RentACar.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace RentACar.Application.DTOs
{
    public class MarcaDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Necessário informar o Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Necessário informar o Status")]
        public StatusCadastro Status { get; set; }
    }
}
