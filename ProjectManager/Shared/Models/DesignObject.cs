using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectManager.Shared.Models
{
    public class DesignObject
    {

        public int Id { get; set; }

        public int? IdParent { get; set; }

        public  DesignObject DesignObjectsParent { get; set; }
        public int IdProject { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public List<DesignObject> DesignObjectsChild { get; set; }
    }
}
