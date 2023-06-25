using TaskMonopoly.Domain.Entities;

namespace TaskMonopoly.Domain.Exceptions
{
    public class BoxSizeExceedsPalletException : Exception
    {
        public BoxSizeExceedsPalletException(Box box, Pallet pallet) : base($"Коробка {box.Id}, не может превышать по размерам паллету {pallet.Id}")
        {

        }
    }
}
