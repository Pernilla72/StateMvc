using System.ComponentModel.DataAnnotations;

namespace StateMvc.Views.Settings;

public class UpdateVM
{

    [Required]
    [EmailAddress]
    [Display(Name = "E-mail")]
    public string? Email { get; set; }

    [Required]
    [Display(Name = "Company Name")]
    public string? CompanyName { get; set; }

    [Required]
    public string? SuccessMessage { get; set; }
}
