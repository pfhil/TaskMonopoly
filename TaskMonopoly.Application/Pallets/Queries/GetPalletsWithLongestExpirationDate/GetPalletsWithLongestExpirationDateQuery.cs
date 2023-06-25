using MediatR;
using TaskMonopoly.Application.Pallets.Queries.ViewModels;

namespace TaskMonopoly.Application.Pallets.Queries.GetPalletsWithLongestExpirationDate
{
    public class GetPalletsWithLongestExpirationDateQuery : IRequest<IEnumerable<PalletVm>>
    {

    }
}
