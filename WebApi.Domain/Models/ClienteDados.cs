using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain.Models
{
    public class ClienteDados : BaseEntity
    {

        public string email { get; set; }
        public string telefone { get; set; }

        [ForeignKey("cliente_id")]
        public virtual Cliente cliente { get; set; }

        [NotMapped]
        public int cliente_id { get; set; }
    }
}
