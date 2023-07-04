using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BaseProject.ViewModels;

namespace BaseProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private readonly HomeViewModel viewModel;
        public HomePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new HomeViewModel(this);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await viewModel.OnLoad();
        }
    }
}