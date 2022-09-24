using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Common.ArtemisAttributes
{
    public class DatabaseViewAttribute: Attribute
    {
        public string ColumnName { get; set; }

        public bool IsKey { get; set; }

        public int Order { get; set; }

    }
}
