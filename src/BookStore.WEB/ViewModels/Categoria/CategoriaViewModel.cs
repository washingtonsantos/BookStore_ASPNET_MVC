using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.WEB.ViewModels.Categoria
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
    }
}
