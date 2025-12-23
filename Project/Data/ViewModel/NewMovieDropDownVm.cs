using System.Collections;

namespace Project.Data.ViewModel
{
    public class NewMovieDropDownVm
    {
         public NewMovieDropDownVm()
        {
            Cinemas = new List<Project.Models.Cinema>();
            Producers = new List<Project.Models.Producert>();
            Actors = new List<Project.Models.Actor>();

        }
        public List<Project.Models.Cinema> Cinemas { get; set; }
        public List<Project.Models.Producert> Producers { get; set; }
        public List<Project.Models.Actor> Actors  { get; set; }
    }
}
