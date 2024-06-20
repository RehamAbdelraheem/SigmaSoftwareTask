using System.ComponentModel.DataAnnotations;

namespace RehamAli.Models
{
    public class Candidate
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the last name", AllowEmptyStrings = false)]
        [MaxLength(250)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter the first name", AllowEmptyStrings = false)]
        [MaxLength(250)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your email", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "Please enter a correct email address")]
        [MaxLength(500)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        [MaxLength(500)]
        public string LinkedinProfileUrl { get; set; }

        [MaxLength (500)]
        public string GithubProfileUrl { get; set; }

        public DateTime BetterDateToCall { get; set;}

        [Range(0, 24)]
        public int BetterStartHourToCall { get; set;}

        [Range(0, 24)]
        public int BetterEndHourToCall { get; set;}


        [Required(ErrorMessage = "Please enter your comment")]
        public string Comment { get; set; }
    }
}
