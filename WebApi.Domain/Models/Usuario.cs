using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Models
{
    public class Usuario : BaseEntity
    {
        public string login { get; set; }
        public string senha { get; set; }
    }
}
