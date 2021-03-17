using System;
using System.Globalization;
using FluentValidation;
using FluentValidation.Results;
using SiteMercadoBackend.Produto.Shared.Contracts;

namespace SiteMercadoBackend.Produto.Commands {
    public class DeleteProductCommand : ICommand {
        public DeleteProductCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
        public bool IsValid()
        {
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");
            ValidationResult ValidationResult;
            ValidationResult = new DeleteProductCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("O Nome do produto é obrigatório.");
        }
    }
}