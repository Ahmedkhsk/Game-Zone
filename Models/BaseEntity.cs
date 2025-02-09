using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
