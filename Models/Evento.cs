
using System.ComponentModel.DataAnnotations;

namespace AtividadeMVC.Models
{
    public class Evento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(80, MinimumLength = 5,
            ErrorMessage = "O nome deve ter entre 5 e 80 caracteres.")]
        public string Nome { get; set; } = "";

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [MinLength(10, ErrorMessage = "A descrição deve ter no mínimo 10 caracteres.")]
        public string Descricao { get; set; } = "";

        [Required(ErrorMessage = "O local é obrigatório.")]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "O local deve ter entre 3 e 100 caracteres.")]
        public string Local { get; set; } = "";

        [Required(ErrorMessage = "A data é obrigatória.")]
        [CustomValidation(typeof(Evento), nameof(ValidarDataEvento))]
        public DateTime DataEvento { get; set; }

        [Range(1, 1000,
            ErrorMessage = "A quantidade deve estar entre 1 e 1000.")]
        public int QuantidadeVagas { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335",
            ErrorMessage = "O valor não pode ser negativo.")]
        public decimal ValorIngresso { get; set; }