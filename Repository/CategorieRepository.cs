

namespace Project.Repository
{
    public class CategorieRepository : ICategorieRepository
    {
        private readonly Context context;

        public CategorieRepository(Context context)
        {
            this.context = context;
        }

        public void Add(Categorie obj)
        {
            context.Add(obj);
        }
        public void Update(Categorie obj)
        {
            context.Update(obj);
        }
        public void Remove(Categorie obj)
        {
            context.Remove(obj);
        }
        public Categorie GetByID(int id)
        {
            return context.Categories.FirstOrDefault(e => e.Id == id);
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public List<Categorie> getAll()
        {
            return context.Categories.ToList();
        }

        public List<SelectListItem> SelectAll()
        {
            return context.Categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .OrderBy(c => c.Text)
                .AsNoTracking()
                .ToList();
        }
    }
}
