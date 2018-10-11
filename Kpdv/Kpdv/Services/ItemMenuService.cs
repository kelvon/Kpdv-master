using Kpdv.Models;
using Kpdv.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Kpdv.Services
{
    public class ItemMenuService
    {
        private static ObservableCollection<Menus> menuLista { get; set; }



        public static ObservableCollection<Menus> RetMenu()
        {
            var painelPage = new Menus() { Nome = "Painel Principal", Icon = "PainelPreto50.png", Pagina = "PainelPage" };
            var PedidoVendaPage = new Menus() { Nome = "Pedido de Venda", Icon = "Pedido50.png", Pagina = "PedidoVendaPage" };
            var ordemServicoPage = new Menus() { Nome = "Ordem de Serviço", Icon = "OrdemServico50.png", Pagina = "OrdemServicoPage" };
            var clientePage = new Menus() { Nome = "Clientes", Icon = "Cliente64.png", Pagina = "ClientePage" };
            var funcionarioPage = new Menus() { Nome = "Profissional", Icon = "Profissional50.png", Pagina = "ProfissionalPage" };
            var produtoPage = new Menus() { Nome = "Produtos", Icon = "Produto32.png", Pagina = "ProdutoPage" };
            var ServicoPage = new Menus() { Nome = "Serviços", Icon = "Service50.png", Pagina = "ServicoPage" };
            var loginPage = new Menus() { Nome = "Sair", Icon = "Sair64.png", Pagina = "Login" };

            menuLista = new ObservableCollection<Menus>();
            menuLista.Add(painelPage);
            menuLista.Add(PedidoVendaPage);
            menuLista.Add(ordemServicoPage);
            menuLista.Add(clientePage);
            menuLista.Add(funcionarioPage);
            menuLista.Add(produtoPage);
            menuLista.Add(ServicoPage);
            menuLista.Add(loginPage);

            return menuLista;



        }
    }
}
