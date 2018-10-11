using Kpdv.Models;
using Kpdv.Services;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kpdv.ViewModels
{
	public class EmpresaDetalhePageViewModel : ViewModelBase
    {
        private int _id;
        private string _cnpj;
        private string _razao;
        private string _fantazia;
        private string _urlBase;
        private string _servidor;
        private string _banco;
        private Empresas _empresa;
        private List<Empresas> ListEmpresas { get; set; }

        private IPageDialogService _dialogService;
        private INavigationService _navigationService;

        /// <summary>
        /// Propriedade Command do botão Adicionar
        /// </summary>
        public DelegateCommand GravarCommand { get; set; }
        /// <summary>
        /// Propriedade Command do botão Excluir
        /// </summary>
        public DelegateCommand ExcluirCommand { get; }
               
        //METODO QUE RECEBE O PARAMETRO ENVIADO PELA PÁGINA
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            _empresa = (Empresas)parameters["Model"]; //pegando o parametro passado
            if (_empresa != null)
            {
                EntryId = _empresa.Id;
                EntryCnpj = _empresa.Cnpj;
                EntryRazao = _empresa.Razao;
                EntryFantazia = _empresa.Fantazia;
                EntryUrlBase = _empresa.UrlBase;
                EntryServidor = _empresa.Servidor;
                EntryBanco = _empresa.Banco;
            }

        }


        public EmpresaDetalhePageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService)
        {
            _navigationService = navigationService; //Navegação
            _dialogService = dialogService; //DisplayAlert 
            GravarCommand = new DelegateCommand(ExecGravar);//AutorizaCon
            ExcluirCommand = new DelegateCommand(ExecExclui);

           

        }

       
        /// <summary>
        /// Metodo do AddCammand que Exclui Conexão no banco
        /// </summary>
        void ExecExclui()
        {

            if (_id > 0)
            {
                //Carrega o arquivo Local se existir
                var LocalFile = Xamarin.Forms.DependencyService.Get<ISaveAndLoad>().LoadText("empresas.json");
                ListEmpresas = JsonConvert.DeserializeObject<List<Empresas>>(LocalFile);
                if (ListEmpresas != null)//Arquivo existe
                {
                    _empresa = ListEmpresas.Where(e => e.Id == this._id).FirstOrDefault(); // Verifica se a empresa existe
                    if (_empresa != null)
                    {
                        foreach (Empresas emp in ListEmpresas)
                        {
                            if (emp.Id == _empresa.Id)
                            {
                                ListEmpresas.Remove(emp);
                                //Serializa o objeto e grava no arquivo local
                                var empresasJson = JsonConvert.SerializeObject(ListEmpresas);
                                Xamarin.Forms.DependencyService.Get<ISaveAndLoad>().SaveText("empresas.json", empresasJson);
                                break;
                            }
                         }
                    }
                    //PASSAR A LISTA ATUALIZADA PARA 
                   //  var navigationParams = new NavigationParameters();
                   //  navigationParams.Add("model", ListEmpresas);
                    _navigationService.GoBackAsync();
                }
                else
                {
                    _dialogService.DisplayAlertAsync("K-PDV", "Não há empresas cadastradas", "OK");

                }

            }
            else
            {
                _dialogService.DisplayAlertAsync("K-PDV", "Empresa não identificada", "OK");
            }
        }
        /// <summary>
        /// Metodo do AddCammand que Insere Conexão no banco
        /// </summary>
        void ExecGravar()
        {
            //Carrega o arquivo Local se existir
            var LocalFile = Xamarin.Forms.DependencyService.Get<ISaveAndLoad>().LoadText("empresas.json");
            ListEmpresas = JsonConvert.DeserializeObject<List<Empresas>>(LocalFile);
            if (ListEmpresas != null)//Arquivo existe
            {
                _empresa = ListEmpresas.Where(e => e.Id == this._id |
                e.Fantazia == this._fantazia).FirstOrDefault(); // Verifica se a empresa existe

                var ultimo_Id = ListEmpresas.Max(e => e.Id); //pega o ultimo ID cadastrado

                if (_empresa == null ) // Cadastro da empresa não existe (INCLUI)
                {
                    _empresa = new Empresas();
                    _empresa.Id = ultimo_Id + 1;
                    _empresa.Cnpj = this._cnpj;
                    _empresa.Razao = this._razao;
                    _empresa.Fantazia = this._fantazia;
                    _empresa.UrlBase = this._urlBase;
                    _empresa.Servidor = this._servidor;
                    _empresa.Banco = this._banco;
                    ListEmpresas.Add(_empresa);
                }
                else//Existe o cadstro da empresa (ALTERA)
                {
                    foreach (Empresas emp in ListEmpresas)
                    {
                        if (emp.Id == _empresa.Id)
                        {
                            emp.Cnpj = this._cnpj;
                            emp.Razao = this._razao;
                            emp.Fantazia = this._fantazia;
                            emp.UrlBase = this._urlBase;
                            emp.Servidor = this._servidor;
                            emp.Banco = this._banco;
                        }
                    }
                }

            }
            else  //Arquivo não existe
            {
                ListEmpresas = new List<Empresas>();
                _empresa = new Empresas();
                _empresa.Id = 1;
                _empresa.Cnpj = this._cnpj;
                _empresa.Razao = this._razao;
                _empresa.Fantazia = this._fantazia;
                _empresa.UrlBase = this._urlBase;
                _empresa.Servidor = this._servidor;
                _empresa.Banco = this._banco;
                ListEmpresas.Add(_empresa);

            }
            //Serializa o objeto e grava no arquivo local
            var empresasJson = JsonConvert.SerializeObject(ListEmpresas);
            Xamarin.Forms.DependencyService.Get<ISaveAndLoad>().SaveText("empresas.json", empresasJson);

            //PASSAR A LISTA ATUALIZADA PARA EmpresaPage
           // var navigationParams = new NavigationParameters();
           // navigationParams.Add("model", ListEmpresas);
            _navigationService.GoBackAsync();


        }
        /// <summary>
        /// Metodo de validação do Cammand. se as Propriedades abaixo estiver preenchido permite executar o metodo principal do Command
        /// </summary>
        /// <returns></returns>
        bool AutorizaCon()
        {
            if (string.IsNullOrWhiteSpace(this._razao) |
                string.IsNullOrWhiteSpace(this._fantazia))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Metodo do NovoCammand que faz a Limpesa dos campos
        /// </summary>
        void ExecNovo()
        {
            this._id = 0;
            this._cnpj = "";
            this._razao = "";
            this._fantazia = "";
            this._urlBase = "";
            this._servidor = "";
            this._banco = "";
        }

        public Empresas Empresa
        {
            get { return _empresa; }
            set
            {
                SetProperty(ref _empresa, value);
            }
        }

        public string EntryBanco
        {
            get { return _banco; }
            set
            {
                SetProperty(ref _banco, value);
            }
        }

        public string EntryServidor
        {
            get { return _servidor; }
            set
            {
                SetProperty(ref _servidor, value);
            }
        }

        public string EntryUrlBase
        {
            get { return _urlBase; }
            set
            {
                SetProperty(ref _urlBase, value);
            }
        }

        public string EntryCnpj
        {
            get { return _cnpj; }
            set
            {
                SetProperty(ref _cnpj, value);
            }
        }

        public string EntryFantazia
        {
            get { return _fantazia; }
            set
            {
                SetProperty(ref _fantazia, value);
                AutorizaCon();
            }
        }

        public string EntryRazao
        {
            get { return _razao; }
            set
            {
                SetProperty(ref _razao, value);
                AutorizaCon();
            }
        }

        public int EntryId
        {
            get { return _id; }
            set
            {
                SetProperty(ref _id, value);
            }
        }
    }
}
