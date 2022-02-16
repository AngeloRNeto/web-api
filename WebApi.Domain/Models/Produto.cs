using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Enums;

namespace WebApi.Domain.Models
{
    public class Produto : BaseEntity
    {
        public string descricao { get; set; }
        public string foto { get; set; }
        public decimal preco { get; set; }
    }
}
