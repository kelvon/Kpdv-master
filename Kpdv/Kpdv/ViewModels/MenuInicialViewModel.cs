using Kpdv.Models;
using Kpdv.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Kpdv.ViewModels
{
	public class MenuInicialViewModel : BindableBase, IMasterDetailPageOptions
	{
        private string _usuario;

        private string LocalFile { get; set; }
        private Usuarios usuarioAsync;

        private INavigationService _navigationService;
        private IPageDialogService _dialogService;

        public ObservableCollection<Menus> ListMenus { get; set; }
        public DelegateCommand<Menus> ItemTappedCommand { get; set; }

        public bool IsPresentedAfterNavigation
        {
            get
            {
                return Device.Idiom != TargetIdiom.Phone;
            }
        }


        public MenuInicialViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService; //Navegação
            _dialogService = dialogService; //DisplayAlert 

            usuarioAsync = new Usuarios();

            ListMenus = new ObservableCollection<Menus>(ItemMenuService.RetMenu());
            ItemTappedCommand = new DelegateCommand<Menus>(MenuSelect);

            LocalFile = Xamarin.Forms.DependencyService.Get<ISaveAndLoad>().LoadText("usuario.json");
            usuarioAsync = JsonConvert.DeserializeObject<Usuarios>(LocalFile);
            if (usuarioAsync != null)
            {
                this._usuario = usuarioAsync.Usuario;
                //   if(Mn!="Sair")
                //       ExecVerif_Login();
            }

        }


        private void MenuSelect(Menus obj)
        {
            var Nome = obj.Nome;
            if (Nome == "Sair")
            {
                LocalFile.Remove(0);
                /*
                var navigationParams = new NavigationParameters();
                navigationParams.Add("Mn", Nome);
                */
                _navigationService.NavigateAsync(new Uri("http://myapp.com/MenuInicial/NavigationPage/Login", UriKind.Absolute)/*, navigationParams*/);
               
            }
            else
            {
                _navigationService.NavigateAsync("NavigationPage/" + obj.Pagina);
            }
           
        }

        public string Usuario
        {
            get { return _usuario; }
            set
            {
                SetProperty(ref _usuario, value);
            }
        }

    }
}
