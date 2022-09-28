using Artemis.Common.ArtemisAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Domain.Entities.Order
{
    public class Order
    {
        [DatabaseView(ColumnName = "OrderNumber", Order = 1)]
        public string OrderNumber { get; set; }

        [DatabaseView(ColumnName = "UserId", Order = 2)]
        public Guid UserId { get; set; }

        [DatabaseView(ColumnName = "AddressId", Order = 3)]
        public Guid AddressId { get; set; }
    }
}
