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
        public float Weight => Boxes.Sum(box => box.Weight) + 30;
        public IList<BoxVm> Boxes { get; set; }
        public DateOnly ExpirationDate => Boxes.Min(box => box.ExpirationDate);
        public float Volume => Boxes.Sum(box => box.Volume) + Width * Height * Depth;

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
                    opt => opt.MapFrom(pallet => pallet.Boxes));
        }
    }
}
