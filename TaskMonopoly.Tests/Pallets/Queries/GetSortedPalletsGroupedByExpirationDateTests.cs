using Shouldly;
using TaskMonopoly.Application.Pallets.Queries.GetSortedPalletsGroupedByExpirationDate;
using TaskMonopoly.Tests.Common;

namespace TaskMonopoly.Tests.Pallets.Queries
{
    public class GetSortedPalletsGroupedByExpirationDateTests : TestQueryBase
    {
        [Fact]
        public async Task GetPalletsWithLongestExpirationDateQueryHandler_Success()
        {
            //Arrange
            var hanlder = new GetSortedPalletsGroupedByExpirationDateQueryHandler(Context, Mapper);

            //Act
            var result = (await hanlder.Handle(new GetSortedPalletsGroupedByExpirationDateQuery(), CancellationToken.None));

            //Assert
            result.Groups.Count().ShouldBe(3);
            result.Groups.Select(group => group.ExpirationDate).ShouldBeInOrder(SortDirection.Ascending);
            result.Groups.Select(group => group.ExpirationDate).ShouldAllBe(date => PalletsGroupedByExpirationDate.Select(group => group.Key).Contains(date));
            foreach (var groupLookupDto in result.Groups)
            {
                groupLookupDto.Pallets.Select(pallet => pallet.Weight).ShouldBeInOrder(SortDirection.Ascending);
                groupLookupDto.Pallets.Select(palletVm => palletVm.Id).ShouldAllBe(id => PalletsGroupedByExpirationDate[groupLookupDto.ExpirationDate].Select(palletVmInDict => palletVmInDict.Id).Contains(id));
            }
        }
    }
}
