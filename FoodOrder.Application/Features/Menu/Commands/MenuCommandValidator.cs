using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrder.Application.Features.Menu.Commands
{
    public class MenuCommandValidator : AbstractValidator<MenuCommand>
    {
        public MenuCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than zero.")
                .LessThanOrEqualTo(1000).WithMessage("Price seems unreasonably high.");
            RuleFor(x => x.Category).IsInEnum().WithMessage("Category must be a valid enum value.");
        }
    }
}
