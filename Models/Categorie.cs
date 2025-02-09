namespace Project.Models
{
    [Table("Categorie")]
    public class Categorie : BaseEntity
    {
        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
