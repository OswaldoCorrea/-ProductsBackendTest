using System;
using System.Globalization;
using FluentValidation;
using FluentValidation.Results;
using SiteMercadoBackend.Produto.Shared.Contracts;

namespace SiteMercadoBackend.Produto.Commands {
    public class UpdateProductCommand : ICommand {
        public UpdateProductCommand()
        {
        }

        public UpdateProductCommand(Guid id, string name, decimal price, string imagePath)
        {
            Id = id;
            Name = name;
            Price = price;
            ImagePath = imagePath;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public bool IsValid()
        {
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");
            ValidationResult ValidationResult;
            ValidationResult = new UpdateProductCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("O Nome do produto é obrigatório.");
            RuleFor(x => x.Price).NotNull().NotEmpty().WithMessage("O Preço do produto é obrigatório.");
        }
    }
}