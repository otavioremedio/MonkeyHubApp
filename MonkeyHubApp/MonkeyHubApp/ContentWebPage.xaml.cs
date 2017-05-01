using MonkeyHubApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonkeyHubApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContentWebPage : ContentPage
    {
        private ContentWebViewModel ViewModel => BindingContext as ContentWebViewModel;

        public ContentWebPage()
        {
            InitializeComponent();
        }
    }
}
