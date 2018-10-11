using Kpdv.Models;
using BackOn.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Kpdv.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        
        private string _nomeusu { get; set; }
        private Usuarios usuarioLogado;
        private List<Usuarios> _listUsuarios;
        private INavigationService _navigationService;
        private IPageDialogService _dialogService;
        private readonly IKontactoAPIService _kontactoAPIService; 
        public ObservableCollection<Pedido_Venda> ListPedidos { get; set; }
       
        

        private int CodPedido, CodVendedor, CodCliente;

        public DelegateCommand<Usuarios> UsusarioSelCommand { get; set; }
        public DelegateCommand<Pedido_Venda> ItemTappedCommand { get; set; }

        //METODO QUE RECEBE O PARAMETRO ENVIADO PELA PÁGINA
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            usuarioLogado = (Usuarios)parameters["model"]; //pegando o parametro passado
           
            //Title = usuarioLogado.Usuario;
        }

       
        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService)
        {
            Title = "Painel";
            _navigationService = navigationService; //Navegação
            _dialogService = dialogService; //DisplayAlert 
            _kontactoAPIService = new KontactoAPIService();
            _nomeusu = "";
            RetListUsuarios();
            //ListUsuarios = new ObservableCollection<Usuarios>();
            UsusarioSelCommand = new DelegateCommand<Usuarios>(UsuarioSelect);
            ItemTappedCommand = new DelegateCommand<Pedido_Venda>(PedidoSelect);
            RetListPedidos();
        }

        private void UsuarioSelect(Usuarios obj)
        {
            CodVendedor = obj.Codigo_int;
        }

        private void PedidoSelect(Pedido_Venda obj)
        {
            Title = obj.CodPedido.ToString();
            
        }

        async void RetListUsuarios()
        {

            string Banco = "BD_REVENDA";
            string Servidor = "gibanweb.database.windows.net";
            //codPedido As Integer, codVendedor As Integer, codCliente As Integer
            string BaseUrl = "http://kontactowapi.azurewebsites.net/api/Usuarios?servidor=" + Servidor + "&banco=" + Banco;

            var strRetorno = await _kontactoAPIService.RetObjetoAsync(BaseUrl);
           
            if (strRetorno != null)
                ListUsuarios = new List<Usuarios>(JsonConvert.DeserializeObject<List<Usuarios>>(strRetorno));
        }

        async void RetListPedidos()
        {

            string Banco = "BD_REVENDA";
            string Servidor = "gibanweb.database.windows.net";
            CodPedido = 0;
            CodVendedor = 98;
            CodCliente = 0;
            string BaseUrl = "http://kontactowapi.azurewebsites.net/api/pedido_venda?servidor=" + Servidor + "&banco=" + Banco + "&codPedido=" + CodPedido + "&codVendedor=" + CodVendedor + "&codCliente=" + CodCliente;

            var strRetorno = await _kontactoAPIService.RetObjetoAsync(BaseUrl);

            if (strRetorno != null)
                ListPedidos = new ObservableCollection<Pedido_Venda>(JsonConvert.DeserializeObject<ObservableCollection<Pedido_Venda>>(strRetorno));
        }
       
      
        public List<Usuarios> ListUsuarios
        {
            get { return _listUsuarios; }
            set
            {
                SetProperty(ref _listUsuarios, value);
            }
        }
    }
}

