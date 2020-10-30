using Pazaar.Application.Interfaces;
using System;

namespace Pazaar.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
