using BeYourMarket.Model.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeYourMarket.Web.Models
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
        [Display(Name = "[[[Code]]]")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "[[[Remember this browser?]]]")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "[[[Email]]]")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "[[[Email]]]")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "[[[Password]]]")]
        public string Password { get; set; }

        [Display(Name = "[[[Remember me?]]]")]
        public bool RememberMe { get; set; }
        public int oqeq { get; set; }
    }

    public class RegisterViewModel
    {
        public RegisterViewModel()
        {
            TiposCadastro = new List<TiposCadastro>();
            EstadosUF = new List<ESTADO>();
            CidadesUF = new List<CIDADE>();
        }

        [Required]
        [EmailAddress]
        [Display(Name = "[[[Email]]]")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "[[[The {0} must be at least {2} characters long.]]]", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "[[[Password]]]")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "[[[Confirm password]]]")]
        [Compare("Password", ErrorMessage = "[[[The password and confirmation password do not match.]]]")]
        public string ConfirmPassword { get; set; }
        
        [Display(Name = "[[[Primeiro Nome]]]")]
        public string FirstName { get; set; }
        
        [Display(Name = "[[[Último nome]]]")]
        public string LastName { get; set; }

        public List<TiposCadastro> TiposCadastro { get; set; }
        public string Usuario { get; set; }
        public string tipoCad { get; set; }
        public string EstadoUF { get; set; }
        public string CidadeUF { get; set; }
        public List<ESTADO> EstadosUF { get; set; }
        public List<CIDADE> CidadesUF { get; set; }
        public string inLogradouro { get; set; }
        public string inBairro { get; set; }
        public string inCep { get; set; }
    }

    public class RegisterCompanyViewModel
    {
        public RegisterCompanyViewModel()
        {
            TiposAtividades = new List<GrupoAtividadesEmpresa>();
        }

        public string Empresa { get; set; }
        public string RazaoSocial { get; set; }
        public string CnpjEmpresa { get; set; }
        public string EnderecoEmpresa { get; set; }
        public string ComplementoEnderecoEmpresa { get; set; }
        public string BairroEmpresa { get; set; }
        public string CidadeEmpresa { get; set; }
        public string UFEmpresa { get; set; }
        public string Fone1Empresa { get; set; }
        public string Email { get; set; }
        public string areaAtuacao { get; set; }

        public List<GrupoAtividadesEmpresa> TiposAtividades { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "[[[Email]]]")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "[[[The {0} must be at least {2} characters long.]]]", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "[[[Password]]]")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "[[[Confirm password]]]")]
        [Compare("Password", ErrorMessage = "[[[The password and confirmation password do not match.]]]")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "[[[Email]]]")]
        public string Email { get; set; }
    }
}
