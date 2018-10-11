using System.Collections;
using System.Windows.Input;
using Xamarin.Forms;

namespace BackOn.Controls
{
    public class ListView : Xamarin.Forms.ListView
    {
        // Propriedade Estatica somente leitura BindableProperty como o nome de ItemTappedCommand
        public static readonly BindableProperty ItemTappedCommandProperty =
          BindableProperty.Create(nameof(ItemTappedCommand),
                            typeof(ICommand),// retorno da minha propriedade
                            typeof(ListView),// O tipo da minha classe
                            null); // valor defaut como nulo
        public ICommand ItemTappedCommand
        {
            get { return (ICommand)GetValue(ItemTappedCommandProperty); }
            set { SetValue(ItemTappedCommandProperty, value); }
        }

        public static readonly BindableProperty InfiniteScrollCommandProperty =
            BindableProperty.Create(nameof(InfiniteScrollCommand),
                    typeof(ICommand),
                    typeof(ListView),
                    null);
        public ICommand InfiniteScrollCommand
        {
            get { return (ICommand)GetValue(InfiniteScrollCommandProperty); }
            set { SetValue(InfiniteScrollCommandProperty, value); }
        }

        public ListView() : this(ListViewCachingStrategy.RecycleElement)
        {
            Initialize();
        }
        //Construtor para setar o ListViewCachingStrategy
        public ListView(ListViewCachingStrategy cachingStrategy) : base(cachingStrategy)
        {
            Initialize();
        }

        private void Initialize()
        {
           // ItemAppearing += InfiniteListView_ItemAppearing;
            //ItemTapped += ListView_ItemTapped;
           
            //quando invocar a propriedade ItemSelected
            this.ItemSelected += (sender, e) =>
            {   //Se não fizeram Binding faz nada
                if (ItemTappedCommand == null)
                    return;
                //Se fizeram Binding chama o canExecute e passo o objeto que é o item selecionado da Lista
                if (ItemTappedCommand.CanExecute(e.SelectedItem))
                    ItemTappedCommand.Execute(e.SelectedItem);
            };
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (ItemTappedCommand != null && ItemTappedCommand.CanExecute(null))
                ItemTappedCommand.Execute(e.Item);
        }

        private void InfiniteListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var items = ItemsSource as IList;
            if (items != null && e.Item == items[items.Count - 3])
            {
                if (InfiniteScrollCommand != null && InfiniteScrollCommand.CanExecute(null))
                    InfiniteScrollCommand.Execute(null);
            }
        }
    }
}