using TaskMonopoly.Domain.Common;

namespace TaskMonopoly.Domain.Entities
{
    public class Pallet : BaseContainer
    {
        public IList<Box> Boxes { get; set; } = new List<Box>();

        public override float Weight => Boxes.Sum(box => box.Weight) + 30;

        public DateOnly ExpirationDate => Boxes.Min(box => box.ExpirationDate);

        public override float Volume => Boxes.Sum(box => box.Volume) + base.Volume;
    }
}
