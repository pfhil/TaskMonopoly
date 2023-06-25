using AutoFixture;
using TaskMonopoly.Application.Common.DTOs;

namespace TaskMonopoly.Tests.Common
{
    public class CustomDeserializedPalletsFixture
    {
        public static Fixture CreateWithValidValue()
        {
            var fixture = new Fixture();
            fixture.Customize<DateOnly>(composer => composer.FromFactory<DateTime>(DateOnly.FromDateTime));

            const float minPalletDepth = 15;
            const float maxPalletDepth = 30;
            const float minPalletWidth = 15;
            const float maxPalletWidth = 30;
            fixture.Customize<DeserializedPallet>(
                c => c
                    .With(
                        desPallet => desPallet.Depth,
                        (float depth) => depth % (maxPalletDepth - minPalletDepth + 1) + minPalletDepth)
                    .With(
                        desPallet => desPallet.Width,
                        (float width) => width % (maxPalletWidth - minPalletWidth + 1) + minPalletWidth)
                    .With(
                        desPallet => desPallet.Boxes,
                        (IList<DeserializedBox> _) => fixture.CreateMany<DeserializedBox>(5).ToList()));

            const float minBoxDepth = 2;
            const float maxBoxDepth = 10;
            const float minBoxWidth = 2;
            const float maxBoxWidth = 10;
            fixture.Customize<DeserializedBox>(
                c => c
                    .With(
                        desBox => desBox.Depth,
                        (float depth) => depth % (maxBoxDepth - minBoxDepth + 1) + minBoxDepth)
                    .With(
                        desBox => desBox.Width,
                        (float width) => width % (maxBoxWidth - minBoxWidth + 1) + minBoxWidth));

            fixture.Customize<JsonWithDeserializedPallets>(
                c => c
                    .With(
                        desPallets => desPallets.Pallets,
                        (IList<DeserializedPallet> _) => fixture.CreateMany<DeserializedPallet>(5).ToList()));

            return fixture;
        }

        public static Fixture CreateWithInvalidSizeValue()
        {
            var fixture = new Fixture();
            fixture.Customize<DateOnly>(composer => composer.FromFactory<DateTime>(DateOnly.FromDateTime));

            const float minPalletDepth = 5;
            const float maxPalletDepth = 30;
            const float minPalletWidth = 5;
            const float maxPalletWidth = 30;
            fixture.Customize<DeserializedPallet>(
                c => c
                    .With(
                        desPallet => desPallet.Depth,
                        (float depth) => depth % (maxPalletDepth - minPalletDepth + 1) + minPalletDepth)
                    .With(
                        desPallet => desPallet.Width,
                        (float width) => width % (maxPalletWidth - minPalletWidth + 1) + minPalletWidth)
                    .With(
                        desPallet => desPallet.Boxes,
                        (IList<DeserializedBox> _) => fixture.CreateMany<DeserializedBox>(5).ToList()));

            const float minBoxDepth = 31;
            const float maxBoxDepth = 50;
            const float minBoxWidth = 31;
            const float maxBoxWidth = 50;
            fixture.Customize<DeserializedBox>(
                c => c
                    .With(
                        desBox => desBox.Depth,
                        (float depth) => depth % (maxBoxDepth - minBoxDepth + 1) + minBoxDepth)
                    .With(
                        desBox => desBox.Width,
                        (float width) => width % (maxBoxWidth - minBoxWidth + 1) + minBoxWidth));

            fixture.Customize<JsonWithDeserializedPallets>(
                c => c
                    .With(
                        desPallets => desPallets.Pallets,
                        (IList<DeserializedPallet> _) => fixture.CreateMany<DeserializedPallet>(5).ToList()));

            return fixture;
        }

        public static Fixture CreateWithInvalidExpirationDateValue()
        {
            var fixture = new Fixture();
            fixture.Customize<DateOnly>(composer => composer.FromFactory<DateTime>(DateOnly.FromDateTime));

            const float minPalletDepth = 15;
            const float maxPalletDepth = 30;
            const float minPalletWidth = 15;
            const float maxPalletWidth = 30;
            fixture.Customize<DeserializedPallet>(
                c => c
                    .With(
                        desPallet => desPallet.Depth,
                        (float depth) => depth % (maxPalletDepth - minPalletDepth + 1) + minPalletDepth)
                    .With(
                        desPallet => desPallet.Width,
                        (float width) => width % (maxPalletWidth - minPalletWidth + 1) + minPalletWidth)
                    .With(
                        desPallet => desPallet.Boxes,
                        (IList<DeserializedBox> _) => fixture.CreateMany<DeserializedBox>(5).ToList()));

            const float minBoxDepth = 2;
            const float maxBoxDepth = 10;
            const float minBoxWidth = 2;
            const float maxBoxWidth = 10;
            fixture.Customize<DeserializedBox>(
                c => c
                    .With(
                        desBox => desBox.Depth,
                        (float depth) => depth % (maxBoxDepth - minBoxDepth + 1) + minBoxDepth)
                    .With(
                        desBox => desBox.Width,
                        (float width) => width % (maxBoxWidth - minBoxWidth + 1) + minBoxWidth)
                    .Without(desBox => desBox.ExpirationDate)
                    .Without(desBox => desBox.ProductionDate));

            fixture.Customize<JsonWithDeserializedPallets>(
                c => c
                    .With(
                        desPallets => desPallets.Pallets,
                        (IList<DeserializedPallet> _) => fixture.CreateMany<DeserializedPallet>(5).ToList()));

            return fixture;
        }

        public static Fixture CreateWithInvalidPalletsValue()
        {
            var fixture = new Fixture();

            fixture.Customize<JsonWithDeserializedPallets>(c => c.Without(desPallets => desPallets.Pallets));

            return fixture;
        }
    }
}
