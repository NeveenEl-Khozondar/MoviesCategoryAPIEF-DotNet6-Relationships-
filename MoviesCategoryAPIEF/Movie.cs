using System.Text.Json.Serialization;

namespace MoviesCategoryAPIEF
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public string Language { get; set; } = String.Empty;

        public int ReleaseYear { get; set; }

        public float Reting { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }

        public int CategoryId { get; set; }
    }
}
