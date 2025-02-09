namespace Project.Models
{
    [Table("Device")]
    public class Device : BaseEntity
    {   
        public string Icon { get; set; } = string.Empty;
    }
}
