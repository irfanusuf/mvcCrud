using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

public class InternApplicationViewModel
{
    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Phone { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public IFormFile Resume { get; set; }  
}
