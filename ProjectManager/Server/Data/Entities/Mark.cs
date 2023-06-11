using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Server.Data.Entities
{
    public class Mark
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ShortName { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
