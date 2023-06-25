using TaskMonopoly.Domain.Exceptions;

namespace TaskMonopoly.Domain.Entities
{
    public class Box
    {
        private DateOnly? _expirationDate;
        private DateOnly? _productionDate;
        public Guid Id { get; set; }
        public Pallet Pallet { get; set; }
        public Guid PalletId { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Depth { get; set; }
        public float Weight { get; set; }

        public DateOnly ExpirationDate
        {
            get => _expirationDate ?? ProductionDate?.AddDays(100) ?? throw new MissingExpirationException(this);
            set => _expirationDate = value;
        }

        public DateOnly? ProductionDate
        {
            get => _productionDate;
            set
            {
                _productionDate = value;
                if (_expirationDate == null && value != null)
                {
                    _expirationDate = value.Value.AddDays(100);
                }
            }
        }

        public float Volume => Width * Height * Depth;
    }
}
