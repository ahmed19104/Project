using Project.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Data.ViewModel
{
    public class NewMovieVm
    {
        public int Id { get; set; }
        [Display(Name ="Movie Name")]
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Display(Name = "Movie Price")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        [Display(Name = "Movie ImageURL")]
        [Required(ErrorMessage = "ImageURL is required")]
        public string ImageURL { get; set; }
        [Display(Name = "Movie Start Date")]
        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Movie End Date")]
        [Required(ErrorMessage = "End Date is required")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Movie Category")]
        [Required(ErrorMessage = "Movie Category is required")]
        public int CinemaId { get; set; }
        [Display(Name = "Movie Category")]
        
        public MovieCategory MovieCategory { get; set; }
        [Display(Name = "Select Movie Category")]
        [Required(ErrorMessage = "Movie Category is required")]
        public int ProducerId { get; set; }
        [Display(Name = "Select Actors")]
        [Required(ErrorMessage = "Actors are required")]
        public List<int> ActorIds { get; set; }

    }
}
