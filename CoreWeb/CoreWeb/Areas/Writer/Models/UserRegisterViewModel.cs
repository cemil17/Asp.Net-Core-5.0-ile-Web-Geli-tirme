using System.ComponentModel.DataAnnotations;


namespace CoreWeb.Areas.Writer.Models
{
	public class UserRegisterViewModel
	{
		[Required(ErrorMessage = "Lütfen Adınızı Girin")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Lütfen Soyadınızı Girin")]
		public string Surname { get; set; }
		[Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Girin")]
		public string UserName { get; set; }
		[Required(ErrorMessage = "Lütfen Parolanızı Girin")]
		public string Password { get; set; }

		[Compare("Password", ErrorMessage = "Şifreler aynı değil !!!")]
		public string ConfirmPassword { get; set; }
		[Required(ErrorMessage = "Lütfen Mail Adresinizi Girin")]
		public string Mail { get; set; }
		[Required(ErrorMessage = "Bu Alanı Boş Bırakmayın")]
		public string ImageURL { get; set; }

	}
}
