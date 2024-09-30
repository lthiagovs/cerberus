using System.ComponentModel.DataAnnotations;

namespace Cerberus.Presentation.WEB.Models
{
    public class AccountRequestModel
    {

        [Required(ErrorMessage = "Email is required.")]
        public string? ResquestEmail {  get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string? RequestPassword {  get; set; }

    }
}
