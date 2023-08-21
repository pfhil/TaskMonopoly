using TaskMonopoly.Domain.Common;
using TaskMonopoly.Domain.Exceptions;

namespace TaskMonopoly.Domain.Entities
{
    public class Box : BaseContainer
    {
        private DateOnly? _expirationDate;
        private DateOnly? _productionDate;

        public Pallet Pallet { get; set; }
        public Guid PalletId { get; set; }

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
    }
}
