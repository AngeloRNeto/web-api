using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Models
{
    public class Cliente : BaseEntity
    {
        public Cliente()
        {
            cliente_dados = new List<ClienteDados>();
        }

        public string nome { get; set; }

        public DateTime data_nascimento { get; set; }
        public string telefone { get; set; }

        public virtual IList<ClienteDados> cliente_dados { get; set; }

        [ForeignKey("endereco_id")]
        public virtual Endereco endereco { get; set; }

        [NotMapped]
        public int endereco_id { get; set; }
    }
}
