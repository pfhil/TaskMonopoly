using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskMonopoly.Application.Common.Interfaces;
using TaskMonopoly.Application.Pallets.Queries.GetPalletList;
using TaskMonopoly.Application.Pallets.Queries.ViewModels;

namespace TaskMonopoly.Application.Pallets.Queries.GetSortedPalletsGroupedByExpirationDate
{
    public class GetSortedPalletsGroupedByExpirationDateQueryHandler
        : IRequestHandler<GetSortedPalletsGroupedByExpirationDateQuery, GroupListVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetSortedPalletsGroupedByExpirationDateQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GroupListVm> Handle(GetSortedPalletsGroupedByExpirationDateQuery request, CancellationToken cancellationToken)
        {
            var pallets = await _context.Pallets.ToListAsync(cancellationToken);

            var groupedPallets = pallets
                .OrderBy(p => p.ExpirationDate)
                .GroupBy(p => p.ExpirationDate)
                .Select(g => new GroupLookupDto()
                {
                    ExpirationDate = g.Key,
                    Pallets = g.OrderBy(p => p.Weight).Select(pallet => _mapper.Map<PalletVm>(pallet))
                });

            //Возможно лучше было бы использовать обычный словарь.
            return new GroupListVm()
            {
                Groups = groupedPallets
            };

        }
    }
}
