using TaskMonopoly.Application.Pallets.Queries.ViewModels;

namespace TaskMonopoly.Application.Pallets.Queries.GetPalletList
{
    public class GroupLookupDto
    {
        public DateOnly ExpirationDate { get; set; }
        public IEnumerable<PalletVm> Pallets { get; set; }
    }
}
