using AutoMapper;
using TaskMonopoly.Application.Common.Mapping;
using TaskMonopoly.Domain.Entities;

namespace TaskMonopoly.Application.Common.DTOs
{
    public class DeserializedBox : IMapWith<Box>
    {
        private DateOnly? _expirationDate;
        public float Width { get; set; }
        public float Height { get; set; }
        public float Depth { get; set; }
        public float Weight { get; set; }

        public DateOnly? ExpirationDate
        {
            get => _expirationDate ?? ProductionDate?.AddDays(100) ?? null;
            set => _expirationDate = value;
        }

        public DateOnly? ProductionDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DeserializedBox, Box>()
                .ForMember(desBox => desBox.Width,
                    opt => opt.MapFrom(box => box.Width))
                .ForMember(desBox => desBox.Height,
                    opt => opt.MapFrom(box => box.Height))
                .ForMember(desBox => desBox.Depth,
                    opt => opt.MapFrom(box => box.Depth))
                .ForMember(desBox => desBox.Weight,
                    opt => opt.MapFrom(box => box.Weight))
                .ForMember(desBox => desBox.ExpirationDate,
                    opt => opt.MapFrom(box => box.ExpirationDate))
                .ForMember(desBox => desBox.ProductionDate,
                    opt => opt.MapFrom(box => box.ProductionDate));

        }
    }
}
