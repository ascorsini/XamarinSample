using BaseProject.ViewModels.Shared;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;

namespace BaseProject.Views.Shared
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfiguracaoPage : PopupPage
    {
        private readonly ConfiguracaoViewModel viewModel;
        public ConfiguracaoPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ConfiguracaoViewModel(this);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await viewModel.OnLoad();
        }
    }
}