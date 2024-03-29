﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Edge.Exago.Application.ViewModels
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }
    }
}
