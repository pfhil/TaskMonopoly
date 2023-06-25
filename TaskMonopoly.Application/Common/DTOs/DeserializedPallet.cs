using AutoMapper;
using TaskMonopoly.Application.Common.Mapping;
using TaskMonopoly.Domain.Entities;

namespace TaskMonopoly.Application.Common.DTOs
{
    public class DeserializedPallet : IMapWith<Pallet>
    {
        public Guid? Id { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Depth { get; set; }
        public IList<DeserializedBox> Boxes { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DeserializedPallet, Pallet>()
                .ForMember(pallet => pallet.Width,
                    opt => opt.MapFrom(desPallet => desPallet.Width))
                .ForMember(pallet => pallet.Height,
                    opt => opt.MapFrom(desPallet => desPallet.Height))
                .ForMember(pallet => pallet.Depth,
                    opt => opt.MapFrom(desPallet => desPallet.Depth))
                .ForMember(pallet => pallet.Boxes,
                    opt => opt.MapFrom(desPallet => desPallet.Boxes))
                .ForMember(pallet => pallet.Id,
                    opt => opt.MapFrom(desPallet => desPallet.Id ?? Guid.NewGuid()));
        }
    }
}
