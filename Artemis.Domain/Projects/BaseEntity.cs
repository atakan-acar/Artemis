using Artemis.Common.ArtemisAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Domain.Projects
{
    public class BaseEntity
    {

        [DatabaseView(ColumnName = "Id", Order = 1, IsKey = true)]
        public int Id { get; set; }

        [DatabaseView(ColumnName = "Başlık", Order = 1, IsKey = false)]
        public string Title { get; set; }
    }
}
