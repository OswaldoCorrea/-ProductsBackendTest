using System.Globalization;
using FluentValidation;
using FluentValidation.Results;
using SiteMercadoBackend.Produto.Shared.Contracts;

namespace SiteMercadoBackend.Produto.Commands {
    public class CreateProductCommand : ICommand {
        public CreateProductCommand()
        {
        }

        public CreateProductCommand(string name, decimal price, string imagePath)
        {
            Name = name;
            Price = price;
            ImagePath = imagePath;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public bool IsValid()
        {
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");
            ValidationResult ValidationResult;
            ValidationResult = new CreateProductCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("O Nome do produto é obrigatório.");
            RuleFor(x => x.Price).NotNull().NotEmpty().WithMessage("O Preço do produto é obrigatório.");
        }
    }
}