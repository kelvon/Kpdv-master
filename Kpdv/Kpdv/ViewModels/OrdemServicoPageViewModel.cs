using BackOn.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kpdv.ViewModels
{
	public class OrdemServicoPageViewModel : ViewModelBase
    {

        private INavigationService _navigationService;
        private IPageDialogService _dialogService;
        private readonly IKontactoAPIService _kontactoAPIService;

        public OrdemServicoPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
               : base(navigationService)
        {
            _navigationService = navigationService; //Navegação
            _dialogService = dialogService; //DisplayAlert 
            _kontactoAPIService = new KontactoAPIService();

        }
	}
}
