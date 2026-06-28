using CommunityToolkit.Mvvm.ComponentModel;

namespace StarWarsTCG.Models
{
    public partial class Card : ObservableObject
    {
        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _subtitle;

        [ObservableProperty]
        private string _rarity;

        [ObservableProperty]
        private string _frontArt;

        public bool HasSubtitle => !string.IsNullOrEmpty(Subtitle);
    }

    public class ApiResponse
    {
        public List<Card> Data { get; set; }
    }
}