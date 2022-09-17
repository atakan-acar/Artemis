using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Domain.Projects.Category
{
    public class Category : BaseEntity, IEntity
    {
        public bool IsHasProduct { get; set; }
        public string Name { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public Guid GuidId { get; set; }
        public string Description { get; set; } = "";
        public string SubDescription { get; set; } = "";
    }
}
