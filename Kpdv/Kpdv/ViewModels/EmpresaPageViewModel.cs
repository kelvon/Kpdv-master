using Kpdv.Models;
using Kpdv.Services;
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
	public class EmpresaPageViewModel : ViewModelBase
    {
        private string LocalFile { get; set; }
        private INavigationService _navigationService;
        private IPageDialogService _dialogService;
        private ObservableCollection<Empresas> _listEmpresas;
        public DelegateCommand AddEmpresaCommand { get; }
        public DelegateCommand<Empresas> ItemTappedCommand { get; set; }



        //METODO QUE É ACIONADO PELA GoBackAsync ou NavigateAsync  DE OUTRA PÁGINA
        public override void OnNavigatedTo(INavigationParameters parameters)
         {
                   
            LocalFile = Xamarin.Forms.DependencyService.Get<ISaveAndLoad>().LoadText("empresas.json");
            ListEmpresas = JsonConvert.DeserializeObject<ObservableCollection<Empresas>>(LocalFile);
        }
       
        public EmpresaPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
              : base(navigationService)
        {
            _navigationService = navigationService; //Navegação
            _dialogService = dialogService; //DisplayAlert 
            ItemTappedCommand = new DelegateCommand<Empresas>(EmpresaSelect);
            AddEmpresaCommand = new DelegateCommand(AddEmpresa);

        }


        private void EmpresaSelect(Empresas parameters)
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add("Model", parameters);
            _navigationService.NavigateAsync("EmpresaDetalhePage", navigationParams);
            //_navigationService.NavigateAsync(new Uri("http://myapp.com/NavegationPage/EmpresaDetalhePage"), navigationParams);
        }

        private void AddEmpresa()
        {
            
            _navigationService.NavigateAsync("EmpresaDetalhePage");
            //_navigationService.NavigateAsync(new Uri("http://myapp.com/NavegationPage/EmpresaDetalhePage"));
        }



        public ObservableCollection<Empresas> ListEmpresas
        {
            get { return _listEmpresas; }
            set
            {
                SetProperty(ref _listEmpresas, value);
            }
        }



    }
}
