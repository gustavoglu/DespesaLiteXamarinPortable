using Despesa.Lite.Xamarin.Portable.Aplicacao;
using Despesa.Lite.Xamarin.Portable.Aplicacao.WebService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Despesa.Lite.Xamarin.Portable.Paginas.Usuario
{
    public class P_UsuarioAddCliente : ContentPage
    {
        StackLayout sl_principal;
        ToolbarItem ti_adicionarClientes;
        ObservableCollection<Domain.Cliente> Clientes;
        ListView listV_Clientes;
        public delegate void ClientesSelecionados(List<Domain.Cliente> ClientesSelecionados);
        public event ClientesSelecionados ClientesSelecionados_Handler;


        public P_UsuarioAddCliente()
        {
            Title = "Adicionar Clientes ao Usuario";

            Clientes = new ObservableCollection<Domain.Cliente>();
            listV_Clientes = new ListView() { HasUnevenRows = true, ItemsSource = Clientes};
            listV_Clientes.ItemTapped += ListV_Clientes_ItemTapped;

            ti_adicionarClientes = new ToolbarItem("Confirmar","", AdicionarClientesEscolhidos);
            this.ToolbarItems.Add(ti_adicionarClientes);

            this.Content = listV_Clientes;
            this.Padding = 30;

            CarregarClientes();

        }

        private void ListV_Clientes_ItemTapped(object sender, ItemTappedEventArgs e)
        {
          
        }

        private async void AdicionarClientesEscolhidos()
        {

            await Navigation.PopModalAsync(true);  
        }

        private async void CarregarClientes()
        {

            try
            {
                var retorno = await WSOpen.GetClientes();

                if (Constantes.Clientes != null && Constantes.Clientes.Count > 0)
                {
                    foreach (var cliente in Constantes.Clientes)
                    {
                        Clientes.Add(cliente);
                    }
                   
                }
            }
            catch
            {

            }
        }
        
    }


}
