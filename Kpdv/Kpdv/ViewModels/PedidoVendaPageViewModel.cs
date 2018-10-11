using BackOn.Services;
using Kpdv.Models;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kpdv.ViewModels
{
	public class PedidoVendaPageViewModel : ViewModelBase
    {

        private Usuarios _usuarioSel;
        private List<Usuarios> _listUsuarios;
        private DateTime _dataSel;
        private INavigationService _navigationService;
        private IPageDialogService _dialogService;
        private readonly IKontactoAPIService _kontactoAPIService;
        public ObservableCollection<Pedido_Venda> ListPedidos { get; set; }

        private int CodPedido, CodVendedor, CodCliente;

        public DelegateCommand UsusarioSelCommand { get; set; }
        public DelegateCommand<Pedido_Venda> ItemTappedCommand { get; set; }
        public DelegateCommand DateSelCommand { get; set; }


        public PedidoVendaPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
           : base(navigationService)
        {
           
            _navigationService = navigationService; //Navegação
            _dialogService = dialogService; //DisplayAlert 
            _kontactoAPIService = new KontactoAPIService();
            RetListUsuarios();
            UsusarioSelCommand = new DelegateCommand(UsuarioSelect);
            ItemTappedCommand = new DelegateCommand<Pedido_Venda>(PedidoSelect);
            DateSelCommand = new DelegateCommand(DateSel);
            RetListPedidos();
            DataSel = DateTime.Now.Date;
        }

       
        private void DateSel()
        {
            var date = DataSel;
        }
        //#4FADEA
        private void UsuarioSelect()
        {
            var CodVendedor = _usuarioSel.Codigo_int;
        }

        private void PedidoSelect(Pedido_Venda obj)
        {
            Title = obj.CodPedido.ToString();

        }

        async void RetListUsuarios()
        {

            string Banco = "pecamicro";
            string Servidor = "Giban";
            //codPedido As Integer, codVendedor As Integer, codCliente As Integer
            string BaseUrl = "http://192.168.0.1/api/usuarios?servidor=" + Servidor + "&banco=" + Banco;

            var strRetorno = await _kontactoAPIService.RetObjetoAsync(BaseUrl);

            if (strRetorno != null)
                ListUsuarios = new List<Usuarios>(JsonConvert.DeserializeObject<List<Usuarios>>(strRetorno));
        }

        async void RetListPedidos()
        {

            string Banco = "pecamicro";
            string Servidor = "Giban";
            CodPedido = 0;
            CodVendedor = 98;
            CodCliente = 0;
            string BaseUrl = "http://192.168.0.1/api/pedido_venda?servidor=" + Servidor + "&banco=" + Banco + "&codPedido=" + CodPedido + "&codVendedor=" + CodVendedor + "&codCliente=" + CodCliente;

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

        public Usuarios UsuarioSel
        {
            get { return _usuarioSel; }
            set
            {
                SetProperty(ref _usuarioSel, value);
            }
        }

        public DateTime DataSel
        {
            get { return _dataSel; }
            set
            {
                SetProperty(ref _dataSel, value);
            }
        }
    }
}
