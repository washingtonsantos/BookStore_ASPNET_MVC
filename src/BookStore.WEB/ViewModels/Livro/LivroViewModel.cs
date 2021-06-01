using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.WEB.ViewModels.Livro
{
    public class LivroViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Nome do Livro")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "ISBN")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Data Lançamento")]
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Categorias")]
        public SelectList Categorias { get; set; }
    }
}
