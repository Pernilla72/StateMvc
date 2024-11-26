using System.ComponentModel.DataAnnotations;

namespace StateMvc.Models
{
    public class UpdateVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        public string CompanyName { get; set; }
    }
}
