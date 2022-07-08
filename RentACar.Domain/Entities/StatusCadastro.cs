using System.ComponentModel.DataAnnotations;

namespace RentACar.Domain.Entities
{
    public enum StatusCadastro
    {
        [Display(Name = "Ativo")]
        Ativo,
        [Display(Name = "Cancelado")]
        Cancelado
    }
        
    public enum StatusVeiculo
    {
        [Display(Name = "Disponível")]
        Disponivel,
        [Display(Name = "Indisponível")]
        Indisponivel,
        [Display(Name = "Vendido")]
        Vendido
    }
}
