using MonkeyHubApp.Services;
using MonkeyHubApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonkeyHubApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriaPage : ContentPage
    {
        private CategoriaViewModel ViewModel => BindingContext as CategoriaViewModel;

        public CategoriaPage()
        {
            InitializeComponent();
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                ViewModel.ShowContentCommand.Execute(e.SelectedItem);
            }
        }
    }
}
