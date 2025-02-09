namespace Project.ViewModel
{
    public class GameFormViewModel
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;


        [Display(Name = "Categorie")]
        public int CategorieId { get; set; }

        [Display(Name = "Suported Devices")]
        public List<int> SelectedDevices { get; set; } = default!;

        //Select List
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();

    }
}
