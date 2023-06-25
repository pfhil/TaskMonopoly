using Shouldly;
using TaskMonopoly.Application.Pallets.Queries.GetPalletsWithLongestExpirationDate;
using TaskMonopoly.Tests.Common;

namespace TaskMonopoly.Tests.Pallets.Queries
{
    public class GetPalletsWithLongestExpirationDateQueryHandlerTests : TestQueryBase
    {
        [Fact]
        public async Task GetPalletsWithLongestExpirationDateQueryHandler_Success()
        {
            //Arrange
            var hanlder = new GetPalletsWithLongestExpirationDateQueryHandler(Context, Mapper);

            //Act
            var result = (await hanlder.Handle(new GetPalletsWithLongestExpirationDateQuery(), CancellationToken.None)).ToList();

            //Assert
            result.Count.ShouldBe(3);
            result.ShouldAllBe(pallet => GuidsOfPalletsWithLongestExpirationDate.Contains(pallet.Id));
            result.Select(pallet => pallet.Volume).ShouldBeInOrder(SortDirection.Ascending);
        }
    }
}
