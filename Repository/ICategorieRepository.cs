namespace Project.Repository
{
    public interface ICategorieRepository
    {
        public void Add(Categorie obj);
        public void Remove(Categorie obj);
        public void Update(Categorie obj);
        public Categorie GetByID(int id);
        public List<Categorie> getAll();
        public List<SelectListItem> SelectAll();
        public void Save();
    }
}
