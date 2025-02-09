namespace Project.Models
{
    [Table("Game")]
    public class Game : BaseEntity
    {
        
        public string Description { get; set; } = string.Empty;
        
        public string Cover { get; set; } = string.Empty;

        [ForeignKey("Categorie"),Display(Name= "Categorie")]
        public int CategorieId { get; set; } 
        public Categorie Categorie { get; set; } = default!;

        public ICollection<GameDevice> Devices { get; set; } = new List<GameDevice>();
    }
}
