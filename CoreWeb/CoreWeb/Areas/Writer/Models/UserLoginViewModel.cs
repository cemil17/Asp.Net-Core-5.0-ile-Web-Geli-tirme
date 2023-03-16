using System.ComponentModel.DataAnnotations;

namespace CoreWeb.Areas.Writer.Models
{
	public class UserLoginViewModel
	{
		[Display(Name = "Kullanıcı Adı")]
		[Required(ErrorMessage = "Kullanıcı Adını Boş Bırakmayın")]
		public string Username { get; set; }
		[Display(Name = "Parola")]
		[Required(ErrorMessage = "Parola Boş Bırakmayın")]
		public string Password { get; set; }
	}
}
