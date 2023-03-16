using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class PortfolioValidator : AbstractValidator<Portfolio>
	{
		public PortfolioValidator() //Constractor Metot
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Proje adı boş geçilemez.");
			RuleFor(x => x.Name).MinimumLength(5).WithMessage("Proje adı minimum 5 (beş) karakterden oluşmaktadır");
			RuleFor(x => x.Name).MaximumLength(100).WithMessage("Proje adı maksimum 100 (yüz) karakterden oluşmaktadır");

			RuleFor(x => x.ImageURL).NotEmpty().WithMessage("Görsel alanı boş geçilemez.");
			RuleFor(x => x.ImageURL).MinimumLength(5).WithMessage("Görsel alanı minimum 5 (beş) karakterden oluşmaktadır");

			RuleFor(x => x.ImageURL2).NotEmpty().WithMessage("Görsel alanı boş geçilemez.");
			RuleFor(x => x.ImageURL).MinimumLength(5).WithMessage("Görsel alanı minimum 5 (beş) karakterden oluşmaktadır");

			RuleFor(x => x.ProjectLink).NotEmpty().WithMessage("Lütfen projeye bir link veriniz.");
			RuleFor(x => x.ProjectLink).MinimumLength(12).WithMessage("Proje linki minimum 12 (on iki) karakterden oluşmaktadır");


		}
	}
}
