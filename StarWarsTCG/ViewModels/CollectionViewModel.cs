using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StarWarsTCG.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace StarWarsTCG.ViewModels
{
    public partial class CollectionViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Card> _collectedCards = new();

        [ObservableProperty]
        private string _collectionStatus = "Total en colección: 0 cartas";

        public ICommand ClearCollectionCommand { get; }
        public ICommand RemoveCardCommand { get; }

        public CollectionViewModel()
        {
            ClearCollectionCommand = new RelayCommand(ExecuteClearCollection);
            RemoveCardCommand = new RelayCommand<Card>(ExecuteRemoveCard);

            UpdateCollectionStatus();
        }

        public void AddCard(Card card)
        {
            if (card == null) return;

            var existingCard = CollectedCards.FirstOrDefault(c => c.Name == card.Name);
            if (existingCard == null)
            {
                CollectedCards.Add(card);
                UpdateCollectionStatus();

                OnPropertyChanged(nameof(CollectedCards));
            }
        }

        public void RefreshCollection()
        {
            OnPropertyChanged(nameof(CollectedCards));
            UpdateCollectionStatus();
        }

        private void ExecuteClearCollection()
        {
            CollectedCards.Clear();
            UpdateCollectionStatus();
        }

        private void ExecuteRemoveCard(Card card)
        {
            if (card != null && CollectedCards.Contains(card))
            {
                CollectedCards.Remove(card);
                UpdateCollectionStatus();
            }
        }

        private void UpdateCollectionStatus()
        {
            CollectionStatus = $"Total en colección: {CollectedCards.Count} cartas";
        }
    }
}