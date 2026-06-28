using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StarWarsTCG.Models;
using StarWarsTCG.Services;
using System.Windows.Input;

namespace StarWarsTCG.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private readonly CardService _cardService = new();

        private List<Card> _cards = new();
        public List<Card> Cards
        {
            get => _cards;
            set => SetProperty(ref _cards, value);
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                SetProperty(ref _isLoading, value);
                OnPropertyChanged(nameof(ShowCards));
            }
        }

        public bool ShowCards => !_isLoading;

        public ICommand AddToCollectionCommand { get; }

        public event Action<Card>? CardAdded;

        public MainViewModel()
        {
            AddToCollectionCommand = new RelayCommand<Card>(ExecuteAddToCollection);
            LoadCards();
        }

        private void ExecuteAddToCollection(Card card)
        {
            if (card == null) return;

            CardAdded?.Invoke(card);
        }

        private async void LoadCards()
        {
            IsLoading = true;
            Cards = await _cardService.GetCardsAsync();
            IsLoading = false;
        }
    }
}