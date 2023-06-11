using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Server.Data.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
