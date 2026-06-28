using StarWarsTCG.Models;
using StarWarsTCG.ViewModels;

namespace StarWarsTCG.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var mainViewModel = BindingContext as MainViewModel;

            if (mainViewModel != null)
            {
                mainViewModel.CardAdded += OnCardAdded;
            }
        }

        private async void OnCardAdded(Card card)
        {
            var collectionVM = AppShell.CollectionVM;

            collectionVM.AddCard(card);

            await DisplayAlert("Éxito", $"¡{card.Name} agregada a tu colección!", "OK");
        }
    }
}