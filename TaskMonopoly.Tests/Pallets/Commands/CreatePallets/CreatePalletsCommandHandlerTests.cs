using AutoFixture;
using Shouldly;
using TaskMonopoly.Application.Common.DTOs;
using TaskMonopoly.Application.Pallets.Commands.CreatePallets;
using TaskMonopoly.Tests.Common;

namespace TaskMonopoly.Tests.Pallets.Commands.CreatePallets
{
    public class CreatePalletsCommandHandlerTests : TestBase
    {
        [Fact]
        public async Task CreatePalletsCommandHandler_Success()
        {
            //Arrange
            var handler = new CreatePalletsCommandHandler(Context, Mapper);
            var fixture = CustomDeserializedPalletsFixture.CreateWithValidValue();
            var deserializedPallets = fixture.Create<JsonWithDeserializedPallets>();

            //Act
            var palletsGuids = await handler.Handle(
                new CreatePalletsCommand
                {
                    Json = deserializedPallets
                },
                CancellationToken.None);

            //Assert
            palletsGuids.ShouldAllBe(id => Context.Pallets.Select(pallet => pallet.Id).Contains(id));

        }
    }
}
