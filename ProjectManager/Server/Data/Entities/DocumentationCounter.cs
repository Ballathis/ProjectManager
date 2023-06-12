using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Server.Data.Entities
{
    public class DocumentationCounter
    {
        [Key]
        public int Id { get; set; }
        public int IdDesignObject { get; set; }
        public int DocumentationCount { get; set; }
    }
}
