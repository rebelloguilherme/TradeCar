using RentACar.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.Application.DTOs
{
    public class VeiculoDTO
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Necessário informar o proprietário")]
        public Proprietario Proprietario { get; set; }
        [DisplayName("Proprietarios")]
        public Guid ProprietarioId { get; set; }
        [Required(ErrorMessage = "Necessário informar o RENAVAM")]
        public string Renavam { get; set; }
        [Required(ErrorMessage = "Necessário informar a marca")]
        public Marca Marca { get; set; }
        [DisplayName("Marcas")]
        public Guid MarcaId { get; set; }
        [Required(ErrorMessage = "Necessário informar o modelo")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "Necessário informar o ano de fabricação")]
        public DateTime AnoFabricacao { get; set; }
        [Required(ErrorMessage = "Necessário informar o ano do modelo")]
        public DateTime AnoModelo { get; set; }
        [Required(ErrorMessage = "Necessário informar a quilometragem")]
        public int Quilometragem { get; set; }
        [Required(ErrorMessage = "Necessário informar o valor")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }
        [Required(ErrorMessage = "Necessário informar o status do veículo")]
        public StatusVeiculo StatusVeiculo { get; set; }
    }
}
