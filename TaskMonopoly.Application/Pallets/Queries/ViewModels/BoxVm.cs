using AutoMapper;
using TaskMonopoly.Application.Common.Mapping;
using TaskMonopoly.Domain.Entities;

namespace TaskMonopoly.Application.Pallets.Queries.ViewModels
{
    public class BoxVm : IMapWith<Box>
    {
        public Guid Id { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Depth { get; set; }
        public float Weight { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public DateOnly? ProductionDate { get; set; }
        public float Volume => Width * Height * Depth;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Box, BoxVm>()
                .ForMember(boxVm => boxVm.Id,
                    opt => opt.MapFrom(box => box.Id))
                .ForMember(boxVm => boxVm.Width,
                    opt => opt.MapFrom(box => box.Width))
                .ForMember(boxVm => boxVm.Height,
                    opt => opt.MapFrom(box => box.Height))
                .ForMember(boxVm => boxVm.Depth,
                    opt => opt.MapFrom(box => box.Depth))
                .ForMember(boxVm => boxVm.Weight,
                    opt => opt.MapFrom(box => box.Weight))
                .ForMember(boxVm => boxVm.ExpirationDate,
                    opt => opt.MapFrom(box => box.ExpirationDate))
                .ForMember(boxVm => boxVm.ProductionDate,
                    opt => opt.MapFrom(box => box.ProductionDate));
        }
    }
}
