namespace TaskMonopoly.Domain.Common
{
    public abstract class BaseContainer
    {
        public virtual Guid Id { get; set; }
        public virtual float Width { get; set; }
        public virtual float Height { get; set; }
        public virtual float Depth { get; set; }
        public virtual float Weight { get; set; }
        public virtual float Volume => Width * Height * Depth;
    }
}
