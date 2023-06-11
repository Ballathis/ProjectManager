using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjectManager.Server.Data.Entities
{
    public class DesignObject
    {
        [Key]
        public int Id { get; set; }
        
        public int? IdParent { get; set; }
        [ForeignKey("IdParent")]
        public virtual DesignObject DesignObjectsParent { get; set; }
        public int IdProject { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey("IdProject")]
        public virtual Project Project { get; set; }
        [NotMapped]
        public string FullCode => DesignObjectsParent is null ? Code : $"{DesignObjectsParent.FullCode}.{Code}";
    }
}
