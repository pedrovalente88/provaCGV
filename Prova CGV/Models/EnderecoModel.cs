using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prova_CGV.Models
{
    public class EnderecoModel
    {
        /// <summary>
        /// Logradouro
        /// </summary>
        [Display(Name = "Logradouro")]
        [Required]
        public string Logradouro { get; set; }

        /// <summary>
        /// Número
        /// </summary>
        [Display(Name = "Número")]
        [Required]
        public int Numero { get; set; }

        /// <summary>
        /// Complemento
        /// </summary>
        [Display(Name = "Complemento")]
        public string Complemento { get; set; }
    }
}