using BaseProject.Bibliotecas.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BaseProject.Views.Shared
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingView : LoadingControl
    {
        public LoadingView()
        {
            InitializeComponent();
        }
    }
}