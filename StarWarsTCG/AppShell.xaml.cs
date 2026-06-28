using StarWarsTCG.ViewModels;
using StarWarsTCG.Views;

namespace StarWarsTCG
{
    public partial class AppShell : Shell
    {
        public static CollectionViewModel CollectionVM { get; private set; }

        public AppShell()
        {
            InitializeComponent();

            CollectionVM = new CollectionViewModel();

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(CollectionPage), typeof(CollectionPage));
        }
    }
}