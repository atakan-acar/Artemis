using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Domain.Projects.h_AppSetings
{
    public class h_AppSettings
    {
        public Guid Id { get; set; }

        public string AppTitle { get; set; }
        public string AppDescription { get; set; }
        public string DocumentUrl { get; set; }
        public int State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
