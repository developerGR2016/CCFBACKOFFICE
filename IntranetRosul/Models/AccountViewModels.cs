using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IntranetRosul.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {

        public string Id { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        public string Primer_Nombre { get; set; }
        public string Primer_Apellido { get; set; }
        public string Segundo_Nombre { get; set; }
        public string Segundo_Apellido { get; set; }
        public string codigo_empleado { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Primer Nombre")]
        public string Primer_Nombre { get; set; }

        [Required]
        [Display(Name = "Segundo Nombre")]
        public string Segundo_Nombre { get; set; }

        [Required]
        [Display(Name = "Primer Apellido")]
        public string Primer_Apellido { get; set; }

        [Required]
        [Display(Name = "Segundo Apellido")]
        public string Segundo_Apellido { get; set; }

        [Required]
        [Display(Name = "Código de Empleado")]
        public int cod_empleado { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {

        [Required]
        [Display(Name = "Primer Nombre")]
        public string Email { get; set; }

        
        [Display(Name = "Segundo Nombre")]
        public string segundo_nombre { get; set; }


        [Required]
        [Display(Name = "Primer Apellido")]
        public string primer_apellido{ get; set; }


        [Display(Name = "Segundo Apellido")]
        public string segundo_apellido { get; set; }


        [Display(Name = "Codigo de Empleado")]
        public string codigo_empleado { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string primer_nombre { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
