using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Livraria.Models
{
    public class Livros
    {
        [Key]
        public int Id { get; set; }

        [StringLength(150, ErrorMessage = "O Titulo deve conter no máximo 150 caracteres", MinimumLength = 1)]        
        public string Titulo { get; set; }

        [StringLength(350, ErrorMessage = "O nome do Autor deve conter no máximo 350 caracteres", MinimumLength = 1)]
        public string Autor { get; set; }

        public Generos Genero { get; set; }

        [DisplayName("Qtd. em estoque")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Atenção, informe um valor numérico, inteiro.")]
        public int QuantidadeEstoque { get; set; }

        [DisplayName("Qtd. de páginas")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Atenção, informe um valor numérico, inteiro.")]
        public int QtdPaginas { get; set; }

        [DisplayName("Data Lançamento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DataLancamento { get; set; }

    }

    public enum Generos
    {
        Aventura,
        Romance,
        Suspense,
        Comédia,
        Terror
    };
   
}