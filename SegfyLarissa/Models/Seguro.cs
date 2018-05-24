using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SegfyLarissa.Models
{
    public class Seguro
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "CPF/CNPJ é obrigatório")]
        [Display(Name = "CPF/CNPJ")]
        public string DocCliente { get; set; }

        [Required(ErrorMessage = "Tipo de Seguro é obrigatório")]
        [Display(Name = "Tipo de Seguro")]
        public TipoSeguro Tipo { get; set; }

        [Required(ErrorMessage = "Objeto segurado é obrigatório")]
        [Display(Name = "Objeto Segurado")]
        public string ObjSegurado { get; set; }

        public string DescricaoTipo()
        {
            var descricao = "";
            if (this.Tipo == TipoSeguro.Automovel)
                descricao = "Automóvel";
            else if (this.Tipo == TipoSeguro.Residencial)
                descricao = "Residencial";
            else if (this.Tipo == TipoSeguro.Vida)
                descricao = "Vida";
            else
                descricao = "";

            return descricao;
        }

        public string ValidaObjetoSegurado(string objeto)
        {
            bool valida = false;
            string msgError = "";

            if (this.Tipo == TipoSeguro.Automovel)
            {
                 valida = Util.ValidaPlaca(objeto);

                if (!valida)
                    msgError = "Placa de veículo inválida para Objeto Segurado."; 
            }
            else if (this.Tipo == TipoSeguro.Vida)
            {
                valida = Util.ValidaCPF(objeto);
                if (!valida)
                {
                    msgError = "CPF inválido para Objeto Segurado.";
                }
            }

            return msgError;
        }
        
    }
}