using Project.Data.Base;

namespace Project.Models
{
    public class Cinema:IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
