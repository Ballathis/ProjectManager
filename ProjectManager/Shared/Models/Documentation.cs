using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Shared.Models
{
    public class Documentation
    {
        public int Id { get; set; }
        public int IdDesignObject { get; set; }
        public int IdMark { get; set; }
        public int Number { get; set; }
    }
}
