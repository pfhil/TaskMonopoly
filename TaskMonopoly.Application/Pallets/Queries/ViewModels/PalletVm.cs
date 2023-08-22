using AutoMapper;
using TaskMonopoly.Application.Common.Mapping;
using TaskMonopoly.Domain.Entities;

namespace TaskMonopoly.Application.Pallets.Queries.ViewModels
{
    public class PalletVm : IMapWith<Pallet>
    {
        public Guid Id { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Depth { get; set; }
        public float Weight { get; set; }
        public IList<BoxVm> Boxes { get; set; } = new List<BoxVm>();
        public DateOnly ExpirationDate { get; set; }
        public float Volume { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Pallet, PalletVm>()
                .ForMember(palletVm => palletVm.Id,
                    opt => opt.MapFrom(pallet => pallet.Id))
                .ForMember(palletVm => palletVm.Width,
                    opt => opt.MapFrom(pallet => pallet.Width))
                .ForMember(palletVm => palletVm.Height,
                    opt => opt.MapFrom(pallet => pallet.Height))
                .ForMember(palletVm => palletVm.Depth,
                    opt => opt.MapFrom(pallet => pallet.Depth))
                .ForMember(palletVm => palletVm.Boxes,
                    opt => opt.MapFrom(pallet => pallet.Boxes))
                .ForMember(palletVm => palletVm.Volume,
                    opt => opt.MapFrom(pallet => pallet.Volume))
                .ForMember(palletVm => palletVm.ExpirationDate,
                    opt => opt.MapFrom(pallet => pallet.ExpirationDate))
                .ForMember(palletVm => palletVm.Weight,
                    opt => opt.MapFrom(pallet => pallet.Weight));
        }
    }
}
