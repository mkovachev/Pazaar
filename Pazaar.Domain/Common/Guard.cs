using Pazaar.Domain.Exceptions;
using Pazaar.Domain.Models;
using System;

namespace Pazaar.Domain.Common
{
    public static class Guard
    {
        public static void AgainstEmptyString<TException>(string value)
            where TException : BaseDomainException, new()
        {
            if (string.IsNullOrEmpty(value))
            {
                ThrowException<TException>($"{value} cannot be null ot empty.");
            }
        }

        public static void ForStringLength<TException>(string value, int minLength, int maxLength)
            where TException : BaseDomainException, new()
        {
            AgainstEmptyString<TException>(value);

            if (minLength > value.Length || value.Length > maxLength)
            {
                ThrowException<TException>($"{value} must have between {minLength} and {maxLength} symbols.");
            }
        }

        public static void AgainstIntOutOfRange<TException>(int number, int min, int max)
            where TException : BaseDomainException, new()
        {
            if (min > number || number > max)
            {
                ThrowException<TException>($"{number} must be between {min} and {max}.");
            }
        }

        public static void AgainstDecimalOutOfRange<TException>(decimal number, decimal min, decimal max)
            where TException : BaseDomainException, new()
        {
            if (min > number || number > max)
            {
                ThrowException<TException>($"{number} must be between {min} and {max}.");
            }
        }

        public static void ForValidUrl<TException>(string url)
            where TException : BaseDomainException, new()
        {
            if (url.Length > ModelConstants.Image.ImageUrlMaxLength ||
                            !Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                ThrowException<TException>($"{url} must be a valid URL.");
            }
        }

        public static void Against<TException>(object actualValue, object unexpectedValue)
            where TException : BaseDomainException, new()
        {
            if (actualValue.Equals(unexpectedValue))
            {
                ThrowException<TException>($"{actualValue} must not be {unexpectedValue}.");
            }
        }

        private static void ThrowException<TException>(string message)
            where TException : BaseDomainException, new()
        {
            var exception = new TException
            {
                Error = message
            };

            throw exception;
        }
    }
}
