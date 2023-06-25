using AutoFixture;
using TaskMonopoly.Application.Pallets.Queries.ViewModels;
using TaskMonopoly.Domain.Entities;

namespace TaskMonopoly.Tests.Common
{
    public abstract class TestQueryBase : TestBase
    {
        protected static readonly DateOnly NormalExpirationDate = DateOnly.FromDateTime(DateTime.Now).AddDays(100);
        protected static readonly DateOnly LowestExpirationDate = NormalExpirationDate.AddDays(-50);
        protected static readonly DateOnly LongestExpirationDate = NormalExpirationDate.AddDays(50);

        protected readonly List<Guid> GuidsOfPalletsWithLongestExpirationDate = new();
        protected readonly Dictionary<DateOnly, IEnumerable<PalletVm>> PalletsGroupedByExpirationDate = new();

        protected TestQueryBase()
        {
            var fixture = new Fixture();

            fixture.Customize<Box>(
                c => c
                    .Without(box => box.ProductionDate)
                    .Without(box => box.ExpirationDate)
                    .Without(box => box.Pallet)
                    .Without(box => box.PalletId));

            fixture.Customize<Pallet>(
                c => c
                    .With(pallet => pallet.Boxes,
                        (IList<Box> _) => fixture.CreateMany<Box>(2).ToList()));


            var pallets = fixture.CreateMany<Pallet>(5).ToList();
            //Паллеты с индексами 0, 2, 3 - имеют коробки с максимальным сроком хранения

            //В группе normalExpirationDate
            pallets[0].Boxes[0].ExpirationDate = NormalExpirationDate;
            pallets[0].Boxes[1].ProductionDate = NormalExpirationDate.AddDays(-100); //ExpirationDate буедт равен то же что и normalExpirationDate

            //В группе lowestExpirationDate
            pallets[1].Boxes[0].ExpirationDate = NormalExpirationDate;
            pallets[1].Boxes[1].ExpirationDate = LowestExpirationDate;

            //В группе longestExpirationDate
            pallets[2].Boxes[0].ExpirationDate = LongestExpirationDate;
            pallets[2].Boxes[1].ExpirationDate = LongestExpirationDate;

            //В группе lowestExpirationDate
            pallets[3].Boxes[0].ProductionDate = LongestExpirationDate.AddDays(-50);
            pallets[3].Boxes[1].ProductionDate = LowestExpirationDate.AddDays(-100);

            //В группе normalExpirationDate
            pallets[4].Boxes[0].ProductionDate = NormalExpirationDate.AddDays(-100);
            pallets[4].Boxes[1].ExpirationDate = NormalExpirationDate;

            GuidsOfPalletsWithLongestExpirationDate.Add(pallets[0].Id);
            GuidsOfPalletsWithLongestExpirationDate.Add(pallets[2].Id);
            GuidsOfPalletsWithLongestExpirationDate.Add(pallets[3].Id);

            PalletsGroupedByExpirationDate.Add(LowestExpirationDate, (new[] { pallets[1], pallets[3] }).Select(pallet => Mapper.Map<PalletVm>(pallet)));
            PalletsGroupedByExpirationDate.Add(NormalExpirationDate, (new[] { pallets[0], pallets[4] }).Select(pallet => Mapper.Map<PalletVm>(pallet)));
            PalletsGroupedByExpirationDate.Add(LongestExpirationDate, (new[] { pallets[2] }).Select(pallet => Mapper.Map<PalletVm>(pallet)));

            Context.Pallets.AddRange(pallets);
            Context.SaveChanges();
        }
    }
}
