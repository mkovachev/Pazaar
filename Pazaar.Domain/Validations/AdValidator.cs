﻿using FluentValidation;
using Pazaar.Domain.Models;
using Pazaar.Domain.Models.Ads;

namespace Pazaar.Domain.Validations
{
    using static ModelConstants.Ad;
    public abstract class AdValidator : AbstractValidator<Ad>
    {
        protected void ValidateTitle()
        {
            RuleFor(ad => ad.Title)
                .NotEmpty().WithMessage("Please add a title")
                .Length(TitleMinLength, TitleMaxLength)
                .WithMessage($"Title must be between {TitleMinLength} and {TitleMaxLength} characters");
        }

        protected void ValidatePrice()
            => RuleFor(ad => ad.Price)
                .NotEmpty().WithMessage("Please add a price")
                .ScalePrecision(2, 2)
                .WithMessage("Price must have exact 2-digits after the decimal point")
                .InclusiveBetween(MinPrice, MaxPrice)
                .WithMessage($"Price must be between {MinPrice} and {MaxPrice}");

        protected void ValidateDescription()
        {
            RuleFor(ad => ad.Description)
                .Length(DescriptionMinLength, DescriptionMaxLength)
                .WithMessage($"Description must be between {DescriptionMinLength} and {DescriptionMaxLength} characters");
        }
    }
}
