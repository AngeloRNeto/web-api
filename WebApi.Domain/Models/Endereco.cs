using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Models
{
    public class Endereco : BaseEntity
    {
        public Endereco()
        {

        }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string uf { get; set; }

        [ForeignKey("cliente_id")]
        public virtual Cliente cliente { get; set; }

        [NotMapped]
        public int cliente_id { get; set; }
    }
}
