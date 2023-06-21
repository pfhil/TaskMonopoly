using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMonopoly.Domain.Exceptions;

namespace TaskMonopoly.Domain.Entities
{
    public class Box
    {
        private DateOnly? _expirationDate;
        public Guid Id { get; set; }
        public int Number { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Depth { get; set; }
        public float Weight { get; set; }
        public DateOnly ExpirationDate
        {
            get => _expirationDate ?? (ProductionDate?.AddDays(100) ?? throw new MissingExpirationException(this));
            set => _expirationDate = value;
        }

        public DateOnly? ProductionDate { get; set; }
        public float Volume => Width * Height * Depth;
    }
}
