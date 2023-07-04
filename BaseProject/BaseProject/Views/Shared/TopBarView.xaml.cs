using BaseProject.Bibliotecas.Controls;
using Xamarin.Forms.Xaml;

namespace BaseProject.Views.Shared
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TopBarView : TopBarControl
    {
        public TopBarView()
        {
            InitializeComponent();
        }
    }
}