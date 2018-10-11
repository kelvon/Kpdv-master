using BackOn.DAO;
using Kpdv.Models;
using BackOn.Services;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using System.IO;
using Kpdv.Services;
using System.Collections.ObjectModel;

namespace Kpdv.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private bool isLoading;
        private string _url;
        private string _servidor;
        private string _banco;

        private string _usuario;
        private string _senha;

        private int _empresaSelIndex;

        private Empresas _empresaSelItem;
        private List<Empresas> _listEmpresas;

        private string LocalFile { get; set; }

        //private Usuarios_Dao ObjDao;
        // private Usuarios usuSqlite;
        private Usuarios usuarioAsync;
        private readonly IKontactoAPIService _kontactoAPIService;

        /// <summary>
        /// Propriedade Command do botão Login
        /// </summary>
        public DelegateCommand LoginCommand { get; }

        /// <summary>
        /// Propriedade Command para navegar Config Empresas
        /// </summary>
        public DelegateCommand EmpresaCommand { get; }

        /// <summary>
        /// Propriedade Command do SelectedItem
        /// </summary>
        public Command EmpresaSelCommand { get; }

        private INavigationService _navigationService;
        private IPageDialogService _dialogService;


        //METODO QUE É ACIONADO PELA GoBackAsync ou NavigateAsync  DE OUTRA PÁGINA
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            LocalFile = Xamarin.Forms.DependencyService.Get<ISaveAndLoad>().LoadText("empresas.json");
            ListEmpresas = JsonConvert.DeserializeObject<List<Empresas>>(LocalFile);
            EmpresaSelIndex = 0;
        }

        //CONTRUTOR
        public LoginViewModel(INavigationService navigationService, IPageDialogService dialogService) //injetando o INavigationService e o serviço DisplayAlert do IPageDialogService
            : base(navigationService)
        {

            _navigationService = navigationService; //Navegação
            _dialogService = dialogService; //DisplayAlert 
            _kontactoAPIService = new KontactoAPIService();

            //    ObjDao = new Usuarios_Dao();
            usuarioAsync = new Usuarios();
            LoginCommand = new DelegateCommand(ExecVerif_Login, AutorizaLogin);
            EmpresaCommand = new DelegateCommand(ExecEmpresa);
            EmpresaSelCommand = new Command(ExecEmpresaSelItem);

            //Verifica se o usuário já se logou alguma vez
            LocalFile = Xamarin.Forms.DependencyService.Get<ISaveAndLoad>().LoadText("usuario.json");
            usuarioAsync = JsonConvert.DeserializeObject<Usuarios>(LocalFile);
            if (usuarioAsync != null)
            {
                this._usuario = usuarioAsync.Usuario;
                this._senha = usuarioAsync.Senha;
                //   if(Mn!="Sair")
                //       ExecVerif_Login();
            }




            //Verifica se já tem usuário no SQLite
            // ObjDao.DeletaUsuario();
            // usuSqlite = new Usuarios();
            // usuSqlite = ObjDao.GetUsuario("");
            //
            // if (usuSqlite != null)
            // {
            //     this._usuario = usuSqlite.Usuario;
            //     this._senha = usuSqlite.Senha;
            //     ExecVerif_Login();
            // }

        }


        /// <summary>
        /// Metodo que chama PushAsync para a navegação de pagina
        /// </summary>
        void ExecEmpresa()
        {
            _navigationService.NavigateAsync("EmpresaPage");
        }

        /// <summary>
        /// Metodo que chama PushAsync para a navegação de pagina
        /// </summary>
        void ExecEmpresaSelItem()
        {
            var Fantazia   = _empresaSelItem.Fantazia;

            this._url      = _empresaSelItem.UrlBase;
            this._servidor = _empresaSelItem.Servidor;
            this._banco    = _empresaSelItem.Banco;
        }
        
        /// <summary>
        /// Metodo que faz a verificação do Login do usuário
        /// </summary>
        async void ExecVerif_Login()
        {
            if ( _empresaSelItem != null ) {
                // await Task.Delay(1000);
                IsLoading = true;

                string Banco    = this._banco;
                string Servidor = this._servidor;

                string BaseUrl = this._url + "/api/Usuarios?servidor=" + Servidor +
                    "&banco=" + Banco +
                    "&nomeUsuario=" + this._usuario +
                    "&senha=" + this._senha;

                string result = await _kontactoAPIService.RetObjetoAsync(BaseUrl);
                usuarioAsync = JsonConvert.DeserializeObject<Usuarios>(result);

                if (usuarioAsync != null)
                {
                    try
                    {
                        //salva o conteudo json local do app
                        Xamarin.Forms.DependencyService.Get<ISaveAndLoad>().SaveText("usuario.json", result);

                        //  if (usuSqlite != null) //Se o usuário já está cadastrado no Sqlite
                        //  {
                        //      int codigo = ObjDao.GravaUsuario(usuarioAsync, true);
                        //  }
                        //  else
                        //  {
                        //      int codigo = ObjDao.GravaUsuario(usuarioAsync, false);
                        //  }
                        //  if (usuarioAsync.Situacao.Trim() != "A")
                        //  {
                        //      await _dialogService.DisplayAlertAsync("Back-On", "Usuário não ativo no sistema!", "OK");
                        //  }
                        //  else
                        //  {

                        //var navigationParams = new NavigationParameters();
                        //navigationParams.Add("model", usuarioAsync);

                        //await _navigationService.NavigateAsync("PainelPage", navigationParams); //Passando Parametros para a 
                        //Navegação Absoluta por Uri
                        await _navigationService.NavigateAsync(new Uri("http://myapp.com/MenuInicial/NavigationPage/PainelPage", UriKind.Absolute));
                        IsLoading = false;
                    }
                    catch (Exception ex)
                    {
                        await _dialogService.DisplayAlertAsync("Back-On", ex.Message, "OK");
                        IsLoading = false;
                    }

                }
                else
                {
                    await _dialogService.DisplayAlertAsync("Back-On", "Usuário e/ou senha invalido(s)!", "OK");
                    IsLoading = false;
                }
            }
            else
            {
                await _dialogService.DisplayAlertAsync("Back-On", "Por favor, selecione uma empresa!", "OK");
            }

            // await App.Current.MainPage.DisplayAlert(Url,"Back-On", "Usuário ou senha invalido(s)!", "OK");
        }

        /// <summary>
        /// Metodo de validação do Cammand. se a Propriedade abaixo estiver preenchido permite executar o metodo principal do Command
        /// </summary>
        /// <returns></returns>
        bool AutorizaLogin()
        {
            return true;//string.IsNullOrWhiteSpace(EntryUsuario) == false;
        }

        public bool IsLoading
        {
            get
            {
                return this.isLoading;
            }

            set
            {
                this.isLoading = value;
                RaisePropertyChanged("IsLoading");

            }
        }

        public string Senha
        {
            get { return _senha; }
            set { SetProperty(ref _senha, value); }
        }

        public string Usuario
        {
            get { return _usuario; }
            set
            {
                SetProperty(ref _usuario, value);
            }
        }

        public int EmpresaSelIndex
        {
            get { return _empresaSelIndex; }
            set
            {
                SetProperty(ref _empresaSelIndex, value);
            }
        }

        public Empresas EmpresaSelItem
        {
            get { return _empresaSelItem; }
            set
            {
                SetProperty(ref _empresaSelItem, value);
            }
        }

        public List<Empresas> ListEmpresas
        {
            get { return _listEmpresas; }
            set
            {
                SetProperty(ref _listEmpresas, value);
            }
        }

    }
}
