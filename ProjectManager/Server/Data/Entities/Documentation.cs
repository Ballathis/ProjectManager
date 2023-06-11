using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Server.Data.Entities
{
    public class Documentation
    {
        [Key]
        public int Id { get; set; }
        public int IdDesignObject { get; set; }
        public int IdMark { get; set; }
        public int Number { get; set; }

        [ForeignKey("IdMark")]
        public virtual Mark Mark { get; set; }
        [ForeignKey("IdDesignObject")]
        public virtual DesignObject DesignObject { get; set; }
    }
}
