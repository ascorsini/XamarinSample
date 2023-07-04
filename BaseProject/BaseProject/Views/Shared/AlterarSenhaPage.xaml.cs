using BaseProject.ViewModels.Shared;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;

namespace BaseProject.Views.Shared
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlterarSenhaPage : PopupPage
    {
        private readonly AlterarSenhaViewModel viewModel;
        public AlterarSenhaPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AlterarSenhaViewModel(this);
        }
    }
}