using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Shared.Models
{
    public class DocumentationInfoFull
    {
        public string ProjectCode { get; set; } = "";
        public string ObjectCode { get; set; } = "";
        public Mark Mark { get; set; }
        public int DocumentationNumber { get; set; }
        public string FullCode { get; set; } = "";
    }
}
