using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using MonkeyHubApp.Models;

namespace MonkeyHubApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private const string BaseUrl = "https://monkey-hub-api.azurewebsites.net/api/";

        public async Task<List<Tag>> GetTagsAsync()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync($"{BaseUrl}Tags").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<List<Tag>>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return null;
        }


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
        
        public ObservableCollection<Tag> Resultados { get; }

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
            Resultados = new ObservableCollection<Tag>();

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
                //await App.Current.MainPage.DisplayAlert("MonkeyHubApp",
                //                                    "Obrigado!",
                //                                    "OK");

                var tagsRetornadasDoServico = await GetTagsAsync();

                Resultados.Clear();

                if (tagsRetornadasDoServico != null)
                {
                    foreach (var tag in tagsRetornadasDoServico)
                    {
                        Resultados.Add(tag);
                    }
                }
                //for (int i = 1; i < 15; i++)
                //{
                //    Resultados.Add($"Sim {i}");
                //}
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
