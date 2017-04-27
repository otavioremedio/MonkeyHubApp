using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace MonkeyHubApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _searchTerm;
        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                if(SetProperty(ref _searchTerm, value))
                    SearchCommand.ChangeCanExecute();
            }
        }
        
        public ObservableCollection<string> Resultados { get; }

        public Command SearchCommand { get; }
        
        //private string _descricao;
        //public string Descricao
        //{
        //    get { return _descricao;}
        //    set {
        //        SetProperty(ref _descricao, value);
        //        //_descricao = value;
        //        //OnPropertyChanged(nameof(Descricao));
        //        //OnPropertyChanged();
        //    }
        //}

        //private string _nome;
        //public string Nome
        //{
        //    get { return _nome; }
        //    set {
        //        SetProperty(ref _nome, value);
        //        //_nome = value;
        //        //OnPropertyChanged(nameof(Nome));
        //        //OnPropertyChanged();
        //    }
        //}

        //private int _idade;

        //public int Idade
        //{
        //    get { return _idade; }
        //    set { SetProperty(ref _idade, value); }
        //}


        public MainViewModel()
        {
            SearchCommand = new Command(ExecuteSearchCommand, CanExecuteSearchCommand);
            Resultados = new ObservableCollection<string>();

            //Descricao = "Olá mundo! Eu estou aqui!";

            //Task.Delay(3000).ContinueWith(async t => {
            //    Descricao = "Meu texto mudou";

            //    for (int i = 0; i < 10; i++)
            //    {
            //        await Task.Delay(1000);
            //        Descricao = $"Meu texto mudou{i}";
            //    }
            //    //if (PropertyChanged != null)
            //    //{
            //    //    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Descricao"));
            //    //}    

            //    //PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Descricao)));


            //});
        }

        bool CanExecuteSearchCommand()
        {
            return string.IsNullOrWhiteSpace(SearchTerm) == false;
        }

        async void ExecuteSearchCommand()
        {
            //await Task.Delay(2000);
            bool resposta = await App.Current.MainPage.DisplayAlert("MonkeyHubApp", 
                                                    $"Você pesquisou por '{SearchTerm}'?", 
                                                    "Sim",
                                                    "Não");

            if (resposta)
            {
                //qq coisa
                await App.Current.MainPage.DisplayAlert("MonkeyHubApp",
                                                   "Obrigado!",
                                                   "OK");
                for (int i = 1; i < 15; i++)
                {
                    Resultados.Add($"Sim {i}");
                }

                

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("MonkeyHubApp",
                                                   "De nada!",
                                                   "OK");
            }
            //Debug.WriteLine($"Clique {DateTime.Now}");
        }
    }
}
