using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain.Models
{
    public class Carrinho: BaseEntity
    {
        public Carrinho()
        {

        }

        public int quantidade { get; set; }

        [ForeignKey("produto_id")]
        public virtual Produto produto { get; set; }

        [ForeignKey("cliente_id")]
        public virtual Cliente cliente { get; set; }

        [NotMapped]
        public int produto_id { get; set; }

        [NotMapped]
        public int cliente_id { get; set; }
    }
}
