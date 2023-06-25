using AutoMapper;
using MediatR;
using TaskMonopoly.Application.Common.Interfaces;
using TaskMonopoly.Domain.Entities;

namespace TaskMonopoly.Application.Pallets.Commands.CreatePallets
{
    public class CreatePalletsCommandHandler : IRequestHandler<CreatePalletsCommand, IEnumerable<Guid>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreatePalletsCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Guid>> Handle(CreatePalletsCommand request, CancellationToken cancellationToken)
        {
            var pallets = request.Json!.Pallets.Select(_mapper.Map<Pallet>).ToList();

            await _context.Pallets.AddRangeAsync(pallets, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return pallets.Select(pallet => pallet.Id);
        }
    }
}
