using Newtonsoft.Json;
using TaskMonopoly.Application.Common.DTOs;
using TaskMonopoly.Application.Common.Interfaces;

namespace TaskMonopoly.Persistence.Services
{
    public class PalletService : IPalletService
    {
        public JsonWithDeserializedPallets? ParsePallets(string json) =>
            JsonConvert.DeserializeObject<JsonWithDeserializedPallets>(json);
    }
}
