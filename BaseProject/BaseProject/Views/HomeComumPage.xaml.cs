using BaseProject.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BaseProject.ViewModels.Base;

namespace BaseProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeComumPage : ContentPage
    {
        //private readonly HomeViewModel viewModel;
        public HomeComumPage()
        {
            InitializeComponent();
            BindingContext =  new BaseViewModel(this);
            //BindingContext = viewModel = new HomeViewModel(this);
        }

        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    await viewModel.OnLoad();
        //}
    }
}