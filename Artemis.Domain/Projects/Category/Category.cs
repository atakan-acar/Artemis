using Artemis.Common.ArtemisAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Domain.Projects.Category
{
    
    public class Category : BaseEntity, IEntity
    {
        [DatabaseView(ColumnName = "HasProduct", Order = 1)]
        public bool IsHasProduct { get; set; }

        [DatabaseView(ColumnName = "Name", Order = 1)]
        public string Name { get; set; } = "";

        [DatabaseView(ColumnName = "CreatedAt", Order = 1)]
        public DateTime CreatedAt { get; set; }

        [DatabaseView(ColumnName = "ModifiedAt", Order = 1)]
        public DateTime ModifiedAt { get; set; }

        [DatabaseView(ColumnName = "Description", Order = 1)]
        public string Description { get; set; } = "";

        [DatabaseView(ColumnName = "SubDescription", Order = 1)]
        public string SubDescription { get; set; } = "";
    }
}
