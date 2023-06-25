using MediatR;
using TaskMonopoly.Application.Pallets.Queries.GetPalletList;

namespace TaskMonopoly.Application.Pallets.Queries.GetSortedPalletsGroupedByExpirationDate
{
    public class GetSortedPalletsGroupedByExpirationDateQuery : IRequest<GroupListVm>
    {

    }
}
