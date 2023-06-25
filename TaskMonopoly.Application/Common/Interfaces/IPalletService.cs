using TaskMonopoly.Application.Common.DTOs;

namespace TaskMonopoly.Application.Common.Interfaces
{
    public interface IPalletService
    {
        public JsonWithDeserializedPallets? ParsePallets(string json);
    }
}
