using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Edge.Exago.Application.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }
    }
}
