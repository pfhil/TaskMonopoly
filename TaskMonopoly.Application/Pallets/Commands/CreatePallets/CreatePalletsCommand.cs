using MediatR;
using TaskMonopoly.Application.Common.DTOs;

namespace TaskMonopoly.Application.Pallets.Commands.CreatePallets
{
    public class CreatePalletsCommand : IRequest<IEnumerable<Guid>>
    {
        public JsonWithDeserializedPallets? Json { get; set; }
    }
}
