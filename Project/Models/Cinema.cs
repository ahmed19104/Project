namespace Project.Models
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
