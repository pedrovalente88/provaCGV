using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prova_CGV.Models
{
    public class AdvogadoModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [Display(Name = "Nome")]
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// Senioridade
        /// </summary>
        [Display(Name = "Senioridade")]
        public int Senioridade { get; set; }

        public static string GetSenioridadeTexto(int id)
        {
            return SenioridadeList.Where(x => x.Value == id.ToString()).FirstOrDefault().Text;
        }

        /// <summary>
        /// Endereço
        /// </summary>
        [Display(Name = "Endereço")]
        public EnderecoModel Endereco { get; set; }

        /// <summary>
        /// Lista de Senioridade para Dropdown
        /// </summary>
        public static List<SelectListItem> SenioridadeList
        {
            get
            {
                var lista = new List<SelectListItem>();

                lista.Add(new SelectListItem
                {
                    Text = string.Empty,
                    Value = "0"
                });

                lista.Add(new SelectListItem
                {
                    Text = "Júnior",
                    Value = "1"
                });

                lista.Add(new SelectListItem
                {
                    Text = "Pleno",
                    Value = "2"
                });

                lista.Add(new SelectListItem
                {
                    Text = "Sênior",
                    Value = "3"
                });

                lista.Add(new SelectListItem
                {
                    Text = "Master",
                    Value = "4"
                });
                
                return lista;
            }
        }

    }
}