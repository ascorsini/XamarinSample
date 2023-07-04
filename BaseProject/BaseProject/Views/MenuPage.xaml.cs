using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BaseProject.ViewModels;

namespace BaseProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        private readonly MenuViewModel viewModel;
        public MenuPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MenuViewModel(this);
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await viewModel.OnLoad();
        }
    }
}