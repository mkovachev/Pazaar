﻿using FluentValidation;
using Pazaar.Domain.Models;
using Pazaar.Domain.Models.Ads;

namespace Pazaar.Application.Validations
{
    using static ModelConstants.Image;
    public abstract class ImageValidator : AbstractValidator<Image>
    {
        protected void ValidateName()
        {
            RuleFor(i => i.Url)
                .NotEmpty().WithMessage("Please add a url")
                .Length(ImageUrlMinLength, ImageUrlMaxLength)
                .WithMessage($"Name must be between {ImageUrlMinLength} and {ImageUrlMaxLength} characters");
        }
    }
}
