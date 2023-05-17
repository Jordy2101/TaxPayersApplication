using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxPayersApplication.Domain.Base
{
    public class BaseEntity
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
