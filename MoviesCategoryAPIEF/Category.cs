namespace MoviesCategoryAPIEF
{
    public class Category
    {
        public int Id { get; set; }

        public string CatName { get; set; } = String.Empty;

        public List<Movie> Movies { get; set; }
    }
}
