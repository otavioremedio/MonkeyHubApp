﻿using System.Threading.Tasks;

namespace MonkeyHubApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _descricao;
        public string Descricao {
            get { return _descricao;}
            set {
                SetProperty(ref _descricao, value);
                //_descricao = value;
                //OnPropertyChanged(nameof(Descricao));
                //OnPropertyChanged();
            }
        }

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set {
                SetProperty(ref _nome, value);
                //_nome = value;
                //OnPropertyChanged(nameof(Nome));
                //OnPropertyChanged();
            }
        }

        private int _idade;

        public int Idade
        {
            get { return _idade; }
            set { SetProperty(ref _idade, value); }
        }


        public MainViewModel()
        {
            Descricao = "Olá mundo! Eu estou aqui!";

            Task.Delay(3000).ContinueWith(async t => {
                Descricao = "Meu texto mudou";

                for (int i = 0; i < 10; i++)
                {
                    await Task.Delay(1000);
                    Descricao = $"Meu texto mudou{i}";
                }
                //if (PropertyChanged != null)
                //{
                //    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Descricao"));
                //}    

                //PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Descricao)));


            });
        }

       
    }
}
