using AutoFixture;
using Shouldly;
using TaskMonopoly.Application.Common.DTOs;
using TaskMonopoly.Application.Pallets.Commands.CreatePallets;
using TaskMonopoly.Tests.Common;

namespace TaskMonopoly.Tests.Pallets.Commands.CreatePallets
{
    public class CreatePalletsCommandValidatorTests : TestBase
    {
        [Fact]
        public async Task CreatePalletsCommandValidator_Success()
        {
            //Arrange
            var fixture = CustomDeserializedPalletsFixture.CreateWithValidValue();
            var deserializedPallets = fixture.Create<JsonWithDeserializedPallets>();
            var command = new CreatePalletsCommand
            {
                Json = deserializedPallets
            };
            var validator = new CreatePalletsCommandValidator();

            //Act
            var result = await validator.ValidateAsync(command);

            //Assert
            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public async Task CreatePalletsCommandValidator_Fail_WhenDataHasInvalidSizeValue()
        {
            //Arrange
            var fixture = CustomDeserializedPalletsFixture.CreateWithInvalidSizeValue();
            var deserializedPallets = fixture.Create<JsonWithDeserializedPallets>();
            var command = new CreatePalletsCommand
            {
                Json = deserializedPallets
            };
            var validator = new CreatePalletsCommandValidator();

            //Act
            var result = await validator.ValidateAsync(command);

            //Assert
            result.IsValid.ShouldBe(false);
        }

        [Fact]
        public async Task CreatePalletsCommandValidator_Fail_WhenDataHasInvalidExpirationDateValue()
        {
            //Arrange
            var fixture = CustomDeserializedPalletsFixture.CreateWithInvalidExpirationDateValue();
            var deserializedPallets = fixture.Create<JsonWithDeserializedPallets>();
            var command = new CreatePalletsCommand
            {
                Json = deserializedPallets
            };
            var validator = new CreatePalletsCommandValidator();

            //Act
            var result = await validator.ValidateAsync(command);

            //Assert
            result.IsValid.ShouldBe(false);
        }

        [Fact]
        public async Task CreatePalletsCommandValidator_Fail_WhenDataHasInvalidPalletsValue()
        {
            //Arrange
            var fixture = CustomDeserializedPalletsFixture.CreateWithInvalidPalletsValue();
            var deserializedPallets = fixture.Create<JsonWithDeserializedPallets>();
            var command = new CreatePalletsCommand
            {
                Json = deserializedPallets
            };
            var validator = new CreatePalletsCommandValidator();

            //Act
            var result = await validator.ValidateAsync(command);

            //Assert
            result.IsValid.ShouldBe(false);
        }
    }
}
