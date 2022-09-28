using Artemis.Common.ArtemisAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Domain.Entities.User
{
    public class User
    {
        [DatabaseView(ColumnName = "Id", Order = 1, IsKey = true)]
        public int Id { get; set; }



        [DatabaseView(ColumnName = "UserName", Order = 2)]
        public string Name { get; set; }
    }
}
