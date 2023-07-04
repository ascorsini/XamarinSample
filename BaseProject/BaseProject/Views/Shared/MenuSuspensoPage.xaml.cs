using BaseProject.ViewModels.Shared;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;
using BaseProject.Models;
using System.Collections.Generic;

namespace BaseProject.Views.Shared
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuSuspensoPage : PopupPage
    {
        private readonly MenuSuspensoViewModel viewModel;
        public MenuSuspensoPage(List<OpcoesMenuSuspenso> opcoes)
        {
            InitializeComponent();
            BindingContext = viewModel = new MenuSuspensoViewModel(this, opcoes);
        }
    }
}