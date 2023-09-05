using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Models
{
    public class School
    {
        public int Id { get; set; }
      
        public string Name { get; set; } = null!;
        public string Sections { get; set; } = null!;
        public string Director { get; set; } = null!;
        [Range(0, 5, ErrorMessage = "value between 1 and 5")]
        public double Rating { get; set; } 
       
        [Url(ErrorMessage = "invalid url")]
        public string? WebSite { get; set; } 
       
    }
}
