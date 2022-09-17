using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Domain.Projects.Product
{
    public class Product : BaseEntity, IEntity
    { 
        public decimal UnitPrice { get; set; }
        public DateTime CreatedAt { get; set; }

        public int StockCount  { get; set; }
        public Guid GuidId { get; set; } 
    }
}
