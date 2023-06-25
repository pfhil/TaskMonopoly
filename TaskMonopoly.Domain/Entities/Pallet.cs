namespace TaskMonopoly.Domain.Entities
{
    public class Pallet
    {
        public Guid Id { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Depth { get; set; }
        public float Weight => Boxes.Sum(box => box.Weight) + 30;
        public IList<Box> Boxes { get; set; }
        public DateOnly ExpirationDate => Boxes.Min(box => box.ExpirationDate);
        public float Volume => Boxes.Sum(box => box.Volume) + Width * Height * Depth;
    }
}
