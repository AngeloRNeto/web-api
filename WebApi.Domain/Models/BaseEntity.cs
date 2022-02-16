using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebApi.Domain.Enums;

namespace WebApi.Domain.Models
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public DateTime data_alteracao { get; set; }
        public DateTime data_criacao { get; set; }
        public ESituacao situacao { get; set; }
    }
}
