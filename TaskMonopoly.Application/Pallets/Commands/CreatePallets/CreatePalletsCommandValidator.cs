using FluentValidation;
using TaskMonopoly.Application.Common.DTOs;

namespace TaskMonopoly.Application.Pallets.Commands.CreatePallets
{
    public class CreatePalletsCommandValidator : AbstractValidator<CreatePalletsCommand>
    {
        public CreatePalletsCommandValidator()
        {
            RuleFor(command => command.Json)
                .NotNull()
                .NotEmpty()
                .WithMessage("Файл не может быть пустым.");

            RuleFor(command => command.Json.Pallets)
                .NotNull()
                .NotEmpty()
                .WithMessage("Коллекция паллет в файле не может быть пустой");

            RuleForEach(command => command.Json!.Pallets)
                .SetValidator(new DeserializedPalletValidator());
        }

        public class DeserializedPalletValidator : AbstractValidator<DeserializedPallet>
        {
            public DeserializedPalletValidator()
            {
                RuleFor(pallet => pallet.Boxes)
                    .NotEmpty()
                    .WithMessage("Паллета должна содержать коробки");

                RuleForEach(pallet => pallet.Boxes)
                    .SetValidator(new DeserializedBoxValidator());

                RuleFor(pallet => pallet)
                    .Must(HaveValidBoxSizes)
                    .WithMessage("Одна или болшье коробок превосходят по размерам паллету");
            }

            private bool HaveValidBoxSizes(DeserializedPallet pallet)
            {
                return pallet.Boxes.All(box =>
                    box.Width <= pallet.Width &&
                    box.Depth <= pallet.Depth
                );
            }
        }

        public class DeserializedBoxValidator : AbstractValidator<DeserializedBox>
        {
            public DeserializedBoxValidator()
            {
                RuleFor(box => box)
                    .Must(box => box.ExpirationDate != null || box.ProductionDate != null)
                    .WithMessage("У коробки должен быть указан срок годности или дата производства.");
            }
        }
    }
}
