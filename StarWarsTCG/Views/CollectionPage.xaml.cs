using StarWarsTCG.ViewModels;

namespace StarWarsTCG.Views
{
    public partial class CollectionPage : ContentPage
    {
        public CollectionPage()
        {
            InitializeComponent();

            BindingContext = AppShell.CollectionVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is CollectionViewModel vm)
            {
                vm.RefreshCollection();
            }
        }
    }
}