using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskMonopoly.Application.Common.Interfaces;
using TaskMonopoly.Application.Pallets.Queries.ViewModels;
using TaskMonopoly.Domain.Entities;

namespace TaskMonopoly.Application.Pallets.Queries.GetPalletsWithLongestExpirationDate
{
    public class GetPalletsWithLongestExpirationDateQueryHandler : IRequestHandler<GetPalletsWithLongestExpirationDateQuery, IEnumerable<PalletVm>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPalletsWithLongestExpirationDateQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PalletVm>> Handle(GetPalletsWithLongestExpirationDateQuery request, CancellationToken cancellationToken)
        {
            var boxesWithLongestExpirationDateQuery = _context.Boxes
                .OrderByDescending(box => box.ExpirationDate)
                .Include(box => box.Pallet);

            var palletsWithBoxesLongestExpirationDate = new List<Pallet>();

            foreach (var box in boxesWithLongestExpirationDateQuery)
            {
                if (!palletsWithBoxesLongestExpirationDate.Any(pallet => pallet.Id == box.PalletId))
                {
                    palletsWithBoxesLongestExpirationDate.Add(box.Pallet);
                    if (palletsWithBoxesLongestExpirationDate.Count == 3)
                    {
                        break;
                    }
                }
            }

            return palletsWithBoxesLongestExpirationDate.OrderBy(pallet => pallet.Volume).Select(pallet => _mapper.Map<PalletVm>(pallet));
        }
    }
}
