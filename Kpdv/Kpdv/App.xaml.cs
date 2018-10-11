using Prism;
using Prism.Ioc;
using Kpdv.ViewModels;
using Kpdv.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using Plugin.Connectivity;
using Prism.Navigation;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Kpdv
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            var navigationParams = new NavigationParameters();
            navigationParams.Add("model", "Start");
            await NavigationService.NavigateAsync("NavigationPage/Login", navigationParams);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<Login>();
            containerRegistry.RegisterForNavigation<MenuInicial>();
            containerRegistry.RegisterForNavigation<ClientePage>();
            containerRegistry.RegisterForNavigation<ProdutoPage>();
            containerRegistry.RegisterForNavigation<ServicoPage>();
            containerRegistry.RegisterForNavigation<OrdemServicoPage>();
            containerRegistry.RegisterForNavigation<ProfissionalPage>();
            containerRegistry.RegisterForNavigation<EmpresaPage>();
            containerRegistry.RegisterForNavigation<EmpresaDetalhePage>();
            containerRegistry.RegisterForNavigation<PainelPage>();
            containerRegistry.RegisterForNavigation<PedidoVendaPage>();
        }

        public bool Conectado()
        {
            bool conectado = CrossConnectivity.Current.IsConnected;
            return conectado;
        }
            
            
            
    }



}
